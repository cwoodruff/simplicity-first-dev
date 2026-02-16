using Microsoft.AspNetCore.Mvc.RazorPages;
using SimplicityFirst.Services;

namespace SimplicityFirst.Pages;

public class SubscribersModel(ISubscriberStore subscriberStore) : PageModel
{
    public List<SubscriberEntry> Subscribers { get; private set; } = [];

    public async Task OnGetAsync()
    {
        Subscribers = await subscriberStore.GetAllSubscribersAsync();
    }
}
