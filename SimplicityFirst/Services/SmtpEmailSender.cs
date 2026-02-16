using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace SimplicityFirst.Services;

public class SmtpEmailSender(IOptions<EmailSettings> options, ILogger<SmtpEmailSender> logger)
    : IEmailSender
{
    private readonly EmailSettings _settings = options.Value;

    public async Task SendConfirmationEmailAsync(string toEmail)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_settings.SenderName, _settings.SenderEmail));
        message.To.Add(MailboxAddress.Parse(toEmail));
        message.Subject = "Welcome to Simplicity-First — You're on the List!";

        var builder = new BodyBuilder
        {
            TextBody = GetPlainTextBody(),
            HtmlBody = GetHtmlBody()
        };
        message.Body = builder.ToMessageBody();

        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_settings.SmtpHost, _settings.SmtpPort,
                _settings.UseSsl ? MailKit.Security.SecureSocketOptions.StartTls
                                 : MailKit.Security.SecureSocketOptions.Auto);
            await client.AuthenticateAsync(_settings.SenderEmail, _settings.SenderPassword);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to send confirmation email to {Email}", toEmail);
            throw;
        }
    }

    private static string GetPlainTextBody() =>
        """
        You're on the list!

        Thanks for signing up to be notified when "Software Architecture Made Simple" launches.

        We'll send you exactly one email when the book is ready — no spam, no fluff.

        Kill the Bloat.
        — The Simplicity-First Team
        https://simplicity-first.dev
        """;

    private static string GetHtmlBody() =>
        """
        <!DOCTYPE html>
        <html>
        <head><meta charset="utf-8" /></head>
        <body style="margin:0;padding:0;background-color:#0a0a0a;font-family:'Barlow',Arial,sans-serif;">
          <table width="100%" cellpadding="0" cellspacing="0" style="background-color:#0a0a0a;padding:40px 20px;">
            <tr><td align="center">
              <table width="600" cellpadding="0" cellspacing="0" style="background-color:#1a1a1a;border:1px solid #333333;border-radius:2px;">
                <tr><td style="border-top:3px solid #E31B23;padding:40px;">
                  <h1 style="margin:0 0 16px;font-size:28px;color:#ffffff;font-family:'Bebas Neue','Barlow',sans-serif;letter-spacing:1px;">
                    You're on the List!
                  </h1>
                  <p style="margin:0 0 16px;font-size:16px;color:#cccccc;line-height:1.6;">
                    Thanks for signing up to be notified when <strong style="color:#ffffff;">"Software Architecture Made Simple"</strong> launches.
                  </p>
                  <p style="margin:0 0 24px;font-size:16px;color:#cccccc;line-height:1.6;">
                    We'll send you exactly one email when the book is ready &mdash; no spam, no fluff.
                  </p>
                  <p style="margin:0;font-size:18px;color:#E31B23;font-weight:600;">
                    Kill the Bloat.
                  </p>
                  <p style="margin:8px 0 0;font-size:14px;color:#999999;">
                    &mdash; The Simplicity-First Team
                  </p>
                </td></tr>
              </table>
            </td></tr>
          </table>
        </body>
        </html>
        """;
}
