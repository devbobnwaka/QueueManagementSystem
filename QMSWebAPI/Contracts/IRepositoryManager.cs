namespace QMSWebAPI.Contracts
{
    public interface IRepositoryManager
    {
        IQueueRepository Queue { get; }
        ISectionRepository Section { get; }

        Task SaveAsync();
    }
}
