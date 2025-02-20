using ApiTester.Application.DTOs;

namespace ApiTester.Domain.Interfaces.IServices
{
    public interface IAccordionService
    {
        Task<AccordionModel> GetAccordionDataAsync(); // Fetch and return structured Accordion data
    }
}
