using QMSWebAPI.Entities.Models;

namespace QMSWebAPI.Contracts
{
    public interface IQueueRepository
    {
        Task<IEnumerable<QueueModel>> GetAllQueuesAsync(bool trachChanges);
        Task<IEnumerable<QueueModel>> GetQueueStatusAsync(string status, bool trackChanges, int limit, int sectionId);
        Task<QueueModel> GetQueueAsync(int id, bool trackChanges);
        void CreateQueue(QueueModel queue);
        void DeleteQueueAsync(int id);
    }
}
