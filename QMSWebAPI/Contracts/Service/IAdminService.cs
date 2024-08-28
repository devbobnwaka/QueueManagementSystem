using Microsoft.AspNetCore.Identity;
using QMSWebAPI.Shared.DataTransferObjects;

namespace QMSWebAPI.Contracts.Service
{
    public interface IAdminService
    {
        Task<IdentityResult> RegisterPersonnel(PersonnelForRegisterDTO personnelForRegister);
    }
}
