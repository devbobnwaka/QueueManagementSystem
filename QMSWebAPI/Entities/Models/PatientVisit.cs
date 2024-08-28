using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QMSWebAPI.Entities.Models
{
    public class PatientVisit
    {
        public int Id { get; set; }
        [Required]
        public int QueueId { get; set; }
        [Required]
        public int SectionId { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public DateTime VisitDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        //NAVIGATION
        [ForeignKey(nameof(QueueId))]
        public QueueModel Queue { get; set; } = null!;
        [ForeignKey(nameof(SectionId))]
        public Section Section { get; set; } = null!;


    }
}
