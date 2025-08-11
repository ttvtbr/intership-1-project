
using System.ComponentModel.DataAnnotations;

namespace intership.DTOs
{
    public class CommentDto
    {
        [Required]
        public int PostId { get; set; }

        [Required, MaxLength(500)]
        public string Content { get; set; }

        [MaxLength(80)]
        public string UserName { get; set; }
    }
}
