using QMSWebAPI.Contracts.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QMSWebAPI.Controllers
{
    [Route("api/section")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly IServiceManager _service;

        public SectionController(IServiceManager service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult> GetSections()
        {
            var sections = await _service.SectionService.GetAllSectionsAsync(trackChanges: false);
            return Ok(sections);
        }
    }
}
