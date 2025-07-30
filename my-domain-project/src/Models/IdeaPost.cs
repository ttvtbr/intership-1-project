public class IdeaPost
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }

    public IdeaPost()
    {
        CreatedAt = DateTime.UtcNow;
    }

    // Additional methods for managing idea posts can be added here
}