namespace SimplicityFirst.Services;

public interface ISubscriberStore
{
    Task<bool> IsAlreadySubscribedAsync(string email);
    Task AddSubscriberAsync(string email);
}
