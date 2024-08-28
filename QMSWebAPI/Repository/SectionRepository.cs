using QMSWebAPI.Contracts;
using QMSWebAPI.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace QMSWebAPI.Repository
{
    public class SectionRepository : RepositoryBase<Section>, ISectionRepository
    {
        public SectionRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
            
        }
        public async Task<IEnumerable<Section>> GetSectionsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<Section> GetSectionAsync(int sectionId, bool trackChanges) 
            => await FindByCondition(q => q.Id.Equals(sectionId), trackChanges).SingleOrDefaultAsync();
    }
}
