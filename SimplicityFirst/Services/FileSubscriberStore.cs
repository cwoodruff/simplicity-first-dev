using Microsoft.Extensions.Options;

namespace SimplicityFirst.Services;

public class FileSubscriberStore : ISubscriberStore
{
    private readonly string _filePath;
    private readonly SemaphoreSlim _lock = new(1, 1);

    public FileSubscriberStore(IOptions<EmailSettings> options, IWebHostEnvironment env)
    {
        var configured = options.Value.SubscriberFilePath;
        _filePath = Path.IsPathRooted(configured)
            ? configured
            : Path.Combine(env.ContentRootPath, configured);

        var directory = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            Directory.CreateDirectory(directory);
    }

    public async Task<bool> IsAlreadySubscribedAsync(string email)
    {
        await _lock.WaitAsync();
        try
        {
            if (!File.Exists(_filePath))
                return false;

            var lines = await File.ReadAllLinesAsync(_filePath);
            return lines.Skip(1).Any(line =>
                line.Split(',')[0].Equals(email, StringComparison.OrdinalIgnoreCase));
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task AddSubscriberAsync(string email)
    {
        await _lock.WaitAsync();
        try
        {
            if (!File.Exists(_filePath))
                await File.WriteAllTextAsync(_filePath, "Email,SubscribedAtUtc\n");

            await File.AppendAllTextAsync(_filePath, $"{email},{DateTime.UtcNow:O}\n");
        }
        finally
        {
            _lock.Release();
        }
    }
}
