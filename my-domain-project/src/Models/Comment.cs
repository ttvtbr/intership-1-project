public class Comment
{
    public int Id { get; set; }
    public int IdeaPostId { get; set; }
    public int UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }

    // Additional methods for handling comments can be added here
}