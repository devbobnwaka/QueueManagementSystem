using Microsoft.AspNetCore.Identity;
using QMSWebAPI.Shared.DataTransferObjects;

namespace QMSWebAPI.Contracts.Service
{
    public interface IAdminService
    {
        Task<IdentityResult> RegisterPersonnel(PersonnelForRegisterDTO personnelForRegister);
        Task<bool> ValidateUser(PersonnelForAuthenticationDTO personnelForAuth);
        Task<TokenDto> CreateToken(bool populateExp);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);

    }
}
