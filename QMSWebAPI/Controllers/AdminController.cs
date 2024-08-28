using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QMSWebAPI.Contracts.Service;
using QMSWebAPI.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Authorization; 

namespace QMSWebAPI.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AdminController(IServiceManager service) => _service = service;

        [HttpPost]
        [Route("register")]
        [Authorize]
        public async Task<IActionResult> RegisterPersonnel([FromBody] PersonnelForRegisterDTO personnelForRegisterDTO)
        {
            var result = await _service.AdminService.RegisterPersonnel(personnelForRegisterDTO);
            if (!result.Succeeded)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }
            return StatusCode(201);
        }
 
    }
}
