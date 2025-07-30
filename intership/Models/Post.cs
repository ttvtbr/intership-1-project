
using System.ComponentModel.DataAnnotations;

namespace intership.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
