using AutoMapper;
using QMSWebAPI.Contracts;
using QMSWebAPI.Contracts.Service;
using QMSWebAPI.Shared.DataTransferObjects;

namespace QMSWebAPI.Service
{
    public class SectionService: ISectionService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public SectionService(IRepositoryManager repository,
            ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SectionDTO>> GetAllSectionsAsync(bool trackChanges)
        {
            var section = await _repository.Section.GetSectionsAsync(trackChanges);
            var sectionDTO = _mapper.Map<IEnumerable<SectionDTO>>(section);
            return sectionDTO;
        }

        public void UpdateSection(int id, SectionUpdateDTO sectionDTO, bool trackchanges)
        {
            var sectionEntity = _repository.Section.GetSectionAsync(id, trackchanges);
            _mapper.Map<SectionUpdateDTO>(sectionEntity);
            _repository.SaveAsync();
        }
    }
}
