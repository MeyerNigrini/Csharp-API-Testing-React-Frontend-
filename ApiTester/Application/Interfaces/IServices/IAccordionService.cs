using ApiTester.Application.Models;

namespace ApiTester.Application.Interfaces.IServices
{
    public interface IAccordionService
    {
        Task<AccordionModel> GetAccordionDataAsync(); // Fetch and return structured Accordion data
    }
}
