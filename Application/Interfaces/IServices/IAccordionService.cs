using Services.Models;

namespace Services.Interfaces.IServices
{
    public interface IAccordionService
    {
        Task<AccordionModel> GetAccordionDataAsync(); // Fetch and return structured Accordion data
    }
}
