namespace QMSWebAPI.Contracts.Service
{
    public interface IServiceManager
    {
        IQueueService QueueService { get; }
        ISectionService SectionService { get; }
        IAdminService AdminService { get; }
    }
}
