namespace QMSWebAPI.Shared.DataTransferObjects
{
    public class QueueCreationDTO 
    {
        public string Name { get; set; } = null!;
        public int SectionId { get; set; }
        public int QueueNumber { get; set; }
    }   
}
