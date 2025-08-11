
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace intership.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string Title { get; set; }

        [Required, MaxLength(1000)]
        public string Content { get; set; }

        [MaxLength(80)]
        public string AuthorName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
    }
}
