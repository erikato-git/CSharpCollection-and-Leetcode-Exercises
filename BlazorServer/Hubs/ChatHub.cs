using Microsoft.AspNetCore.SignalR;

namespace BlazorServer.Hubs;        // Namespace very important for some reason!!

public class ChatHub : Hub
{
    public Task SendMessage(string user, string message)
    {
        return Clients.All.SendAsync("ReceiveMessage", user, message);     // message to all the "server's" clients
    }
}


//namespace BlazorServer.Hubs
//{
//    public class ChatHub : Hub
//    {
//        public Task SendMessage(string user, string message)
//        {
//            return Clients.All.SendAsync("ReceiveMessage:", user, message);     // message to all the "server's" clients
//        }

//    }
//}
