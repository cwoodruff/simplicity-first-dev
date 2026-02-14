using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Markdig;

namespace SimplicityFirst.Pages;

public class EssayModel(IWebHostEnvironment environment) : PageModel
{
    public string? HtmlContent { get; private set; }
    public string? Title { get; private set; }

    public IActionResult OnGet(string slug)
    {
        if (string.IsNullOrEmpty(slug))
        {
            return NotFound();
        }

        var filePath = Path.Combine(environment.ContentRootPath, "Essays", $"{slug}.md");

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }

        var markdown = System.IO.File.ReadAllText(filePath);
        
        // Simple extraction of title from first H1 if it exists
        if (markdown.StartsWith("# "))
        {
            var endOfLine = markdown.IndexOf('\n');
            Title = markdown.Substring(2, endOfLine - 2).Trim();
        }
        else
        {
            Title = "Essay";
        }

        var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
        HtmlContent = Markdown.ToHtml(markdown, pipeline);

        return Page();
    }
}
