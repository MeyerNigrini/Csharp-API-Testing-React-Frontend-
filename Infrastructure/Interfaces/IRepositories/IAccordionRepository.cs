using Infrastructure.Entities;

namespace Infrastructure.Interfaces.IRepositories
{
    public interface IAccordionRepository
    {
        // IAccordionRepository defines the data access contract for Accordion data
        Task<List<AccordionEntity>> GetAccordionDataAsync();
    }
}
