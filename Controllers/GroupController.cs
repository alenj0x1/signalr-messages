using Microsoft.AspNetCore.Mvc;
using SignalRMessages.Classes;
using SignalRMessages.Models;

namespace SignalRMessages.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupController(Cache<Message> cache) : ControllerBase
{
    private readonly Cache<Message> _cache = cache;
    
    [HttpGet("{groupId}")]
    public IActionResult GetMessagesByGroup(string groupId)
    {
        try
        {
            return Ok(_cache.Get().Where(msg => msg.GroupId == groupId));
        }
        catch (Exception e)
        {
            return BadRequest([]);
        }
    }
}