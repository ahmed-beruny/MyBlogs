using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MyBlogs.Controllers;
[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase{
    private readonly appDbContext _context;
    public PostController(appDbContext context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetPosts")]
    public async Task<ActionResult<IEnumerable<Posts>>> GetPosts()
    {
        return await _context.Posts.ToListAsync();
    }

    [HttpGet("{id}", Name = "GetPost")]
    public async Task<ActionResult<Posts>> GetPost(int id)
    {
        var post = await _context.Posts.FindAsync(id);

        if (post == null)
        {
            return NotFound();
        }

        return post;
    }

    [HttpPost(Name = "CreatePost")]
    public async Task<ActionResult<Posts>> CreatePost(Posts post)
    {
        _context.Posts.Add(post);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
    }

    [HttpPut("{id}", Name = "UpdatePost")]
    public async Task<IActionResult> UpdatePost(int id, Posts post)
    {
        if (id != post.Id)
        {
            return BadRequest();
        }

        _context.Entry(post).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeletePost")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var post = await _context.Posts.FindAsync(id);

        if (post == null)
        {
            return NotFound();
        }

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}