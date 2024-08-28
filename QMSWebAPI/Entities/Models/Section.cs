using System.ComponentModel.DataAnnotations;

namespace QMSWebAPI.Entities.Models
{
    public class Section
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public int CurrentQueueNumber { get; set; }
        public DateTime LastRestDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        //public ICollection<User> Users { get; set; } = new List<User>();
    }
}
