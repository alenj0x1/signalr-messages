using Microsoft.AspNetCore.SignalR;

namespace SignalRMessages.Hubs;

public class ChatHub : Hub
{
    public async Task MemberWriting(string groupId, string user)
    {
        await Clients.Group(groupId).SendAsync("UserWriting", user);
    }
    
    public async Task JoinGroup(string groupId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
    }

    public async Task SendMessage(string groupId, string user, string message)
    {
        await Clients.Group(groupId).SendAsync("ReceiveMessage", user, message);
    }

    public async Task LeaveGroup(string groupId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
    }
}