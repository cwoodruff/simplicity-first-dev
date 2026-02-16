using Microsoft.AspNetCore.Mvc.RazorPages;
using Markdig;

namespace SimplicityFirst.Pages;

public class ManifestoModel(IWebHostEnvironment environment) : PageModel
{
    public string? HtmlContent { get; private set; }

    public void OnGet()
    {
        var filePath = Path.Combine(environment.ContentRootPath, "manifesto.md");

        if (!System.IO.File.Exists(filePath))
            return;

        var markdown = System.IO.File.ReadAllText(filePath);
        var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
        HtmlContent = Markdown.ToHtml(markdown, pipeline);
    }
}
