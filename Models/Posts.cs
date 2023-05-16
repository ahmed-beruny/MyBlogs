
public class Posts
{
    public int Id { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }="";
    public string Body { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string ImageUrl { get; set; } = "";
    public List<Comments> Comments { get; set; } = new List<Comments>();
}