namespace SimplicityFirst.Services;

public record SubscriberEntry(string Email, DateTime SubscribedAtUtc);

public interface ISubscriberStore
{
    Task<bool> IsAlreadySubscribedAsync(string email);
    Task AddSubscriberAsync(string email);
    Task<List<SubscriberEntry>> GetAllSubscribersAsync();
}
