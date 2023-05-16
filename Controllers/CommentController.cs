
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyBlogs.Controllers;
[ApiController]
[Route("[controller]")]
public class CommentController : ControllerBase{
    private readonly appDbContext _context;
    public CommentController(appDbContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetComments")]
    public async Task<ActionResult<IEnumerable<Comments>>> GetComments()
    {
        return await _context.Comments.ToListAsync();
    }

    [HttpGet("{id}", Name = "GetComment")]
    public async Task<ActionResult<Comments>> GetComment(int id)
    {
        var comment = await _context.Comments.FindAsync(id);

        if (comment == null)
        {
            return NotFound();
        }

        return comment;
    }

    [HttpPost(Name = "CreateComment")]
    public async Task<ActionResult<Comments>> CreateComment(Comments comment)
    {
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
    }

    [HttpPut("{id}", Name = "UpdateComment")]
    public async Task<IActionResult> UpdateComment(int id, Comments comment)
    {
        if (id != comment.Id)
        {
            return BadRequest();
        }

        _context.Entry(comment).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteComment")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var comment = await _context.Comments.FindAsync(id);

        if (comment == null)
        {
            return NotFound();
        }

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}