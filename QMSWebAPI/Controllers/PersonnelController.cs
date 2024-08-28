using Microsoft.AspNetCore.Mvc;
using QMSWebAPI.Contracts.Service;

namespace QMSWebAPI.Controllers
{
    [Route("api/personnel")]
    [ApiController]
    public class PersonnelController(IServiceManager service) : ControllerBase
    {
        private readonly IServiceManager _service = service;


    }
}
