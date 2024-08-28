using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QMSWebAPI.Contracts;
using QMSWebAPI.Contracts.Service;
using QMSWebAPI.Entities.Models;

namespace QMSWebAPI.Service
{
    public class ServiceManager : IServiceManager
    {
        private  readonly Lazy<IQueueService> _queueService;
        private readonly Lazy<ISectionService> _sectionService;
        private readonly Lazy<IAdminService> _adminService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper,
            UserManager<User> userManager, IConfiguration configuration)
        {
            _queueService = new Lazy<IQueueService>(()
                => new QueueService(repository, logger, mapper));
            _sectionService = new Lazy<ISectionService>(()
                => new SectionService(repository, logger, mapper));
            _adminService = new Lazy<IAdminService>(()
                => new AdminService(userManager, logger, mapper, configuration));
        }
        public IQueueService QueueService => _queueService.Value;
        public ISectionService SectionService => _sectionService.Value;
        public IAdminService AdminService => _adminService.Value;
    }
}
