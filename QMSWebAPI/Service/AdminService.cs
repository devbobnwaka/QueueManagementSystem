using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QMSWebAPI.Contracts;
using QMSWebAPI.Contracts.Service;
using QMSWebAPI.Entities.Models;
using QMSWebAPI.Shared.DataTransferObjects;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

//using QMSWebAPI.Entities.Models;

namespace QMSWebAPI.Service
{
    public class AdminService: IAdminService
    {
        private readonly UserManager<User> _userManager;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        private User? _user;
        public AdminService(
            UserManager<User> userManager, ILoggerManager logger,
            IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _configuration = configuration;
        }


        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("API_SECRET_KEY"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
             {
                 new Claim(ClaimTypes.Name, _user.UserName)
             };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings["validIssuer"],
            audience: jwtSettings["validAudience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
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

        public async Task<bool> ValidateUser(PersonnelForAuthenticationDTO personnelForAuth)
        {
            _user = await _userManager.FindByNameAsync(personnelForAuth.UserName);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, personnelForAuth.Password));
            if (!result)
                _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Wrong user name or password.");
            return result;
        }

       
    }
}
