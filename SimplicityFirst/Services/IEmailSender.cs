namespace SimplicityFirst.Services;

public interface IEmailSender
{
    Task SendConfirmationEmailAsync(string toEmail);
}
