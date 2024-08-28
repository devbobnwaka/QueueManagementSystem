using QMSWebAPI.Contracts.Service;
using QMSWebAPI.Entities.Models;
using QMSWebAPI.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QMSWebAPI.Controllers
{
    [Route("api/queues")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly IServiceManager _service;
        public QueueController(IServiceManager service) 
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetQueues()
        {
            var queues = await _service.QueueService.GetAllQueuesAsync(trackChanges:false);
            return Ok(queues);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetQueue(int id)
        {
            var queue = await _service.QueueService.GetQueueAsync(id, trackChanges: false);
            return Ok(queue);   
        }

        [HttpGet("status/{sectionId:int}")]
        public async Task<IActionResult> GetCurrentQueueStatus(int sectionId)
        {
            var queues = await _service.QueueService.GetQueueStatusAsync
                ("waiting", trackChanges: false, limit:4, sectionId);
            return Ok(queues);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQueue([FromBody] QueueRequestDTO model)
        {
            int currentQueueNumber;
            var sections = await _service.SectionService.GetAllSectionsAsync(trackChanges: false);
            var sectionObj =  sections.FirstOrDefault(obj => obj.Id == model.SectionId);

            if (sectionObj != null)
            {
                currentQueueNumber = sectionObj.CurrentQueueNumber;
                var queueDTO = await _service.QueueService.CreateQueueAsync(model, currentQueueNumber);
                //return Ok(queueDTO);
                return CreatedAtAction(nameof(GetQueue), new { id = queueDTO.Id }, queueDTO );
            }
            return BadRequest();         
        }
    }
}
