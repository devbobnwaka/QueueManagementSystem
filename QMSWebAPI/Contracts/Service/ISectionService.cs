using QMSWebAPI.Shared.DataTransferObjects;

namespace QMSWebAPI.Contracts.Service
{
    public interface ISectionService
    {
        Task<IEnumerable<SectionDTO>> GetAllSectionsAsync(bool trackChanges);
        void UpdateSection(int id, SectionUpdateDTO section, bool trackchanges); 
    }
}
