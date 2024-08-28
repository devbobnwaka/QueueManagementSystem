using QMSWebAPI.Contracts;
using QMSWebAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace QMSWebAPI.Repository
{
    public class QueueRepository : RepositoryBase<QueueModel>, IQueueRepository
    {
        public QueueRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {

        }
        public void CreateQueue(QueueModel queue) => Create(queue);

        public async Task<IEnumerable<QueueModel>> GetAllQueuesAsync(bool trachChanges)
        {
            return await FindAll(trachChanges).ToListAsync();
        }

        public async Task<QueueModel> GetQueueAsync(int queueId, bool trackChanges) => 
            await FindByCondition(q => q.Id.Equals(queueId), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<QueueModel>> GetQueueStatusAsync
            (string status, bool trackChanges, int limit, int sectionId)
        {
            if (limit < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(limit), "Limit must be greater than 0.");
            }

            var query = FindByCondition(
                q => q.Status.Equals(status) && q.SectionId.Equals(sectionId),
                trackChanges
            );

            return await query.Take(limit).ToListAsync();
        }


        void IQueueRepository.DeleteQueueAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
