using QMSWebAPI.Entities.Models;
using QMSWebAPI.Shared.DataTransferObjects;

namespace QMSWebAPI.Contracts.Service
{
    public interface IQueueService
    {
        Task<IEnumerable<QueueDTO>> GetAllQueuesAsync(bool trackChanges);
        Task<IEnumerable<QueueDTO>> GetQueueStatusAsync(string status, bool trackChanges, int limit, int sectionId);
        Task<QueueDTO> CreateQueueAsync(QueueRequestDTO queueDTO, int currentQueueNumber);
        Task<QueueDTO> GetQueueAsync(int id, bool trackChanges);

    }
}
