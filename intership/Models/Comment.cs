
using System;
using System.ComponentModel.DataAnnotations;

namespace intership.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required, MaxLength(500)]
        public string Content { get; set; }

        [MaxLength(80)]
        public string UserName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Post Post { get; set; }
    }
}
