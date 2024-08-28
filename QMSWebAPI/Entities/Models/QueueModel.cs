using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QMSWebAPI.Entities.Models
{
    public class QueueModel
    {
        public int Id { get; set; }
        [Required]
        public int SectionId { get; set; }
        [Required]
        public int QueueNumber { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Status { get; set; } = "waiting";
        public DateTime CalledAt { get; set; }
        public DateTime ServedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(SectionId))]
        public Section Section { get; set; } = null!;

    }
}
