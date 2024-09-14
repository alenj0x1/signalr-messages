namespace SignalRMessages.Models;

public class Message
{
    public string GroupId { get; set; } = null!;
    public string User { get; set; } = null!;
    public string Content { get; set; } = null!;
}