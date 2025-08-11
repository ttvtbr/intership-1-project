
using System.ComponentModel.DataAnnotations;

namespace intership.DTOs
{
    public class PostDto
    {
        [Required, MaxLength(150)]
        public string Title { get; set; }

        [Required, MaxLength(1000)]
        public string Content { get; set; }

        [MaxLength(80)]
        public string AuthorName { get; set; }
    }
}
