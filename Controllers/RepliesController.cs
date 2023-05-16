using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyBlogs.Controllers;
[ApiController]
[Route("[controller]")]
public class RepliesController : ControllerBase{
    private readonly appDbContext _context;
    public RepliesController(appDbContext context)
    {
        _context = context;
    }
    [HttpGet(Name = "GetReplies")]
    public async Task<ActionResult<IEnumerable<Replies>>> GetReplies()
    {
        return await _context.Replies.ToListAsync();
    }
    [HttpGet("{id}", Name = "GetReply")]
    public async Task<ActionResult<Replies>> GetReply(int id)
    {
        var reply = await _context.Replies.FindAsync(id);
        if (reply == null)
        {
            return NotFound();
        }
        return reply;
    }
    [HttpPost(Name = "CreateReply")]
    public async Task<ActionResult<Replies>> CreateReply(Replies reply)
    {
        _context.Replies.Add(reply);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetReply), new { id = reply.Id }, reply);
    }
    [HttpPut("{id}", Name = "UpdateReply")]
    public async Task<IActionResult> UpdateReply(int id, Replies reply)
    {
        if (id != reply.Id)
        {
            return BadRequest();
        }
        _context.Entry(reply).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpDelete("{id}", Name = "DeleteReply")]
    public async Task<IActionResult> DeleteReply(int id)
    {
        var reply = await _context.Replies.FindAsync(id);
        if (reply == null)
        {
            return NotFound();
        }
        _context.Replies.Remove(reply);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}