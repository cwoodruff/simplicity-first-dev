using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimplicityFirst.Services;

namespace SimplicityFirst.Pages;

public class EssayInfo
{
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
}

public class SubscribeResultModel
{
    public bool Success { get; set; }
    public bool AlreadySubscribed { get; set; }
    public string Message { get; set; } = string.Empty;
}

public class IndexModel(
    IWebHostEnvironment environment,
    ISubscriberStore subscriberStore,
    IEmailSender emailSender,
    ILogger<IndexModel> logger) : PageModel
{
    public List<EssayInfo> Essays { get; private set; } = [];

    [BindProperty]
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [StringLength(254)]
    public string SubscriberEmail { get; set; } = string.Empty;

    public void OnGet()
    {
        LoadEssays();
    }

    public async Task<IActionResult> OnPostSubscribeAsync()
    {
        var result = new SubscribeResultModel();

        if (!ModelState.IsValid)
        {
            result.Message = "Please enter a valid email address.";
            return Partial("_SubscribeResult", result);
        }

        try
        {
            if (await subscriberStore.IsAlreadySubscribedAsync(SubscriberEmail))
            {
                result.Success = true;
                result.AlreadySubscribed = true;
                result.Message = "You're already on the list! We'll email you when the book launches.";
                return Partial("_SubscribeResult", result);
            }

            await subscriberStore.AddSubscriberAsync(SubscriberEmail);

            result.Success = true;
            result.Message = "You're in! We'll email you when the book launches.";

            // _ = Task.Run(async () =>
            // {
            //     try
            //     {
            //         await emailSender.SendConfirmationEmailAsync(SubscriberEmail);
            //     }
            //     catch (Exception ex)
            //     {
            //         logger.LogError(ex, "Failed to send confirmation email to {Email}", SubscriberEmail);
            //     }
            // });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Subscription failed for {Email}", SubscriberEmail);
            result.Message = "Something went wrong. Please try again.";
        }

        return Partial("_SubscribeResult", result);
    }

    private void LoadEssays()
    {
        var essaysPath = Path.Combine(environment.ContentRootPath, "Essays");
        if (Directory.Exists(essaysPath))
        {
            var files = Directory.GetFiles(essaysPath, "*.md");
            foreach (var file in files)
            {
                var slug = Path.GetFileNameWithoutExtension(file);
                var content = System.IO.File.ReadAllLines(file);
                var title = content.FirstOrDefault(l => l.StartsWith("# "))?.Substring(2) ?? slug;
                var summary = content.FirstOrDefault(l => !string.IsNullOrWhiteSpace(l) && !l.StartsWith("#")) ?? "";

                Essays.Add(new EssayInfo
                {
                    Slug = slug,
                    Title = title,
                    Summary = summary
                });
            }
        }
    }
}
