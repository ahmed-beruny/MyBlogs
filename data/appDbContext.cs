
using Microsoft.EntityFrameworkCore;

public class appDbContext : DbContext
{
    public appDbContext(DbContextOptions<appDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Posts>().HasMany(p => p.Comments).WithOne().HasForeignKey(c => c.PostId);
        modelBuilder.Entity<Comments>().HasMany(c => c.Replies).WithOne().HasForeignKey(r => r.CommentId);
    }


    public DbSet<Posts> Posts { get; set; }
    public DbSet<Comments> Comments { get; set; }
    public DbSet<Replies> Replies { get; set; }

    
}
