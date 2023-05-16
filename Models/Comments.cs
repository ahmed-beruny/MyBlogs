using System.ComponentModel.DataAnnotations.Schema;

public class Comments{
    public int Id { get; set; }
    public string Author { get; set; }
    public string Body { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [ForeignKey("PostId")]
    public int PostId { get; set; }
    //public Posts Post { get; set; } = new Posts();
    public List<Replies> Replies { get; set; } = new List<Replies>();

}