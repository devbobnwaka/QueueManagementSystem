using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QMSWebAPI.Contracts.Service;
using QMSWebAPI.Shared.DataTransferObjects;

namespace QMSWebAPI.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServiceManager _service;
        public TokenController(IServiceManager service) => _service = service;

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokenDto)
        {
            var tokenDtoToReturn = await
            _service.AdminService.RefreshToken(tokenDto);
            return Ok(tokenDtoToReturn);
        }

    }
}
