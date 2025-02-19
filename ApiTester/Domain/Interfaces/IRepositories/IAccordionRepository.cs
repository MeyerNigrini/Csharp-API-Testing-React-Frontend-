using ApiTester.Domain.Models;

namespace ApiTester.Domain.Interfaces.IRepositories
{
    public interface IAccordionRepository
    {
        // IAccordionRepository defines the data access contract for Accordion data
        Task<List<AccordionModel>> GetAccordionDataAsync();
    }
}
