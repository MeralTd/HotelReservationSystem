using Microsoft.AspNetCore.SignalR.Client;

HubConnection connection = new HubConnectionBuilder()
    .WithUrl("https://localhost:7159/notificationHub")
    .Build();


connection.On<string>("ReceiveReservationNotification", async reservation =>
{
    Console.WriteLine(reservation);
});

try
{
    await connection.StartAsync();
    Console.WriteLine($"ConnectionID : {connection.ConnectionId}");

    Console.WriteLine("Notifications awaited...");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}



Console.ReadLine(); // Uygulamanın açık kalmasını sağlar