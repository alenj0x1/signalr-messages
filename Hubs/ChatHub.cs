using Microsoft.AspNetCore.SignalR;
using SignalRMessages.Classes;
using SignalRMessages.Models;

namespace SignalRMessages.Hubs;

public class ChatHub(Cache<Message> cache) : Hub
{
    private readonly Cache<Message> _cache = cache;
    
    public async Task MemberWriting(string groupId, string user)
    {
        await Clients.Group(groupId).SendAsync("UserWriting", user);
    }
    
    public async Task JoinGroup(string groupId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupId);
        
    }

    public async Task SendMessage(Message message)
    {
        _cache.Add(message);
        
        await Clients.Group(message.GroupId).SendAsync("ReceiveMessage", message);
    }

    public async Task LeaveGroup(string groupId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupId);
    }
}