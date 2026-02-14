using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SimplicityFirst.Pages;

public class EssayInfo
{
    public string Slug { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
}

public class IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment environment) : PageModel
{
    public List<EssayInfo> Essays { get; private set; } = [];

    public void OnGet()
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
