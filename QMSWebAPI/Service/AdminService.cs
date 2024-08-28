using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QMSWebAPI.Contracts;
using QMSWebAPI.Contracts.Service;
using QMSWebAPI.Entities.Models;
using QMSWebAPI.Shared.DataTransferObjects;

//using QMSWebAPI.Entities.Models;

namespace QMSWebAPI.Service
{
    public class AdminService: IAdminService
    {
        private readonly UserManager<User> _userManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AdminService(
            UserManager<User> userManager, ILoggerManager logger,
            IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterPersonnel(PersonnelForRegisterDTO personnelForRegistration)
        {
            var personnel = _mapper.Map<User>(personnelForRegistration);
            var result = await _userManager.CreateAsync(personnel, personnelForRegistration.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(personnel, personnelForRegistration.Role);
            }
            return result;
        }
    }
}
