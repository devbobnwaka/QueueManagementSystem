using AutoMapper;
using QMSWebAPI.Entities.Models;
using QMSWebAPI.Shared.DataTransferObjects;

namespace QMSWebAPI
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<QueueModel, QueueDTO>();
            CreateMap<QueueDTO, QueueModel>();
            CreateMap<QueueCreationDTO, QueueModel>();
            CreateMap<QueueRequestDTO, QueueCreationDTO>();
            CreateMap<Section,  SectionDTO>();
            CreateMap<SectionUpdateDTO, Section>();
            CreateMap<PersonnelForRegisterDTO, User>();
        }
    }
}
