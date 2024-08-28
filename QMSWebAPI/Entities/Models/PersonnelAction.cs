using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QMSWebAPI.Entities.Models
{
    public class PersonnelAction
    {
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; } = null!;
        [Required]
        public int SectionId { get; set; }
        [Required]
        public int QueueId { get; set; }
        [Required]
        public string Action { get; set; } = null!;
        [Required]
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } = null!;
        [ForeignKey(nameof(SectionId))]
        public virtual Section Section { get; set; } = null!;
        [ForeignKey(nameof(QueueId))]
        public virtual QueueModel Queue { get; set; } = null!;
    }
}
