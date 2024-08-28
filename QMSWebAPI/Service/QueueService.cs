using AutoMapper;
using QMSWebAPI.Contracts;
using QMSWebAPI.Contracts.Service;
using QMSWebAPI.Entities.Models;
using QMSWebAPI.Shared.DataTransferObjects;

namespace QMSWebAPI.Service
{
    public class QueueService: IQueueService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public QueueService(
            IRepositoryManager repository, 
            ILoggerManager logger, 
            IMapper mapper) 
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<QueueDTO> CreateQueueAsync(QueueRequestDTO queueRDTO, int currentQueueNumber)
        {
            var queueDTO = _mapper.Map<QueueCreationDTO>(queueRDTO);
            queueDTO.QueueNumber = currentQueueNumber + 1;

            int sectionID = queueDTO.SectionId;
            var sectionEntity = await _repository.Section.GetSectionAsync(sectionID, true);
            sectionEntity.CurrentQueueNumber = queueDTO.QueueNumber;

            var queueModel = _mapper.Map<QueueModel>(queueDTO);
            _repository.Queue.CreateQueue(queueModel);
            await _repository.SaveAsync();
            var returnedQueue = _mapper.Map<QueueDTO>(queueModel);
            return returnedQueue;
        }

        public async Task<IEnumerable<QueueDTO>> GetAllQueuesAsync(bool trackChanges)
        {
            var queues = await _repository.Queue.GetAllQueuesAsync(trackChanges);
            var queueDTO = _mapper.Map<IEnumerable<QueueDTO>>(queues);
            return queueDTO;
        }

        public async Task<QueueDTO> GetQueueAsync(int id, bool trackChanges)
        {
            var queue = await _repository.Queue.GetQueueAsync(id, trackChanges);
            var queueDTO = _mapper.Map<QueueDTO>(queue);
            return queueDTO;
        }

        public async Task<IEnumerable<QueueDTO>> 
            GetQueueStatusAsync(string status, bool trackChanges, int limit, int sectionId)
        {
            var queues = await _repository.Queue.GetQueueStatusAsync(status, trackChanges, limit, sectionId);
            var queueDTO = _mapper.Map<IEnumerable<QueueDTO>>(queues);
            return queueDTO;
        }

        //public async Task<QueueD>
    }
}
