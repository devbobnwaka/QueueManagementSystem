namespace QMSWebAPI.Shared.DataTransferObjects
{
    public record SectionDTO(
        int Id, 
        string Name, 
        int CurrentQueueNumber, 
        DateTime LastRestDate,
        DateTime CreatedAt, 
        DateTime UpdatedAt
        );


}
