
using System;

namespace intership.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string UserName { get; set; }  // simple username capture
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Post Post { get; set; }
    }
}
