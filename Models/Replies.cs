using System.ComponentModel.DataAnnotations.Schema;

public class Replies
{
    public int Id { get; set; }
    public string Author { get; set; }
    public string Body { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [ForeignKey("CommentId")]
    public int CommentId { get; set; }
    //public Comments Comment { get; set; } = new Comments();
}