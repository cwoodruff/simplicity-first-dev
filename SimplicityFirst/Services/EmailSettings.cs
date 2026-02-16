namespace SimplicityFirst.Services;

public class EmailSettings
{
    public string SmtpHost { get; set; } = "smtp.gmail.com";
    public int SmtpPort { get; set; } = 587;
    public bool UseSsl { get; set; } = true;
    public string SenderEmail { get; set; } = string.Empty;
    public string SenderName { get; set; } = "Simplicity-First";
    public string SenderPassword { get; set; } = string.Empty;
    public string SubscriberFilePath { get; set; } = "Data/subscribers.csv";
}
