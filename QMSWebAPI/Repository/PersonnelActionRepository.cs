using QMSWebAPI.Contracts;
using QMSWebAPI.Entities.Models;

namespace QMSWebAPI.Repository
{
    public class PersonnelActionRepository: RepositoryBase<PersonnelAction>, IPersonnelActionRepository
    {
        public PersonnelActionRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
            
        }
    }
}
