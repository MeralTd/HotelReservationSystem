using Microsoft.AspNetCore.SignalR;

namespace Application.Hubs;

public class NotificationHub : Hub
{

    public async Task SendReservationNotification(string message)
    {
        await Clients.All.SendAsync("ReceiveReservationNotification", message);
    }
}
