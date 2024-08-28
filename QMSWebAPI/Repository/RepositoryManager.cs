using QMSWebAPI.Contracts;

namespace QMSWebAPI.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IQueueRepository> _queueRepository;
        private readonly Lazy<ISectionRepository> _sectionRepository;

        public RepositoryManager(RepositoryContext respositoryContext)
        {
            _repositoryContext = respositoryContext;
            _queueRepository = new Lazy<IQueueRepository>(()
                => new QueueRepository(respositoryContext));
            _sectionRepository = new Lazy<ISectionRepository>(() 
                => new SectionRepository( respositoryContext));
        }
        public IQueueRepository Queue => _queueRepository.Value;

        public ISectionRepository Section => _sectionRepository.Value;

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
