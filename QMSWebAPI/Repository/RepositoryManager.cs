using QMSWebAPI.Contracts;

namespace QMSWebAPI.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IQueueRepository> _queueRepository;
        private readonly Lazy<ISectionRepository> _sectionRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _queueRepository = new Lazy<IQueueRepository>(()
                => new QueueRepository(repositoryContext));
            _sectionRepository = new Lazy<ISectionRepository>(() 
                => new SectionRepository( repositoryContext));
        }
        public IQueueRepository Queue => _queueRepository.Value;

        public ISectionRepository Section => _sectionRepository.Value;

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
