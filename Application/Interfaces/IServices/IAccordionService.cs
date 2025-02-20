using Application.Models;

namespace Application.Interfaces.IServices
{
    public interface IAccordionService
    {
        Task<AccordionModel> GetAccordionDataAsync(); // Fetch and return structured Accordion data
    }
}
