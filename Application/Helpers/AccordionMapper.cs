using Application.Models;
using Domain.Entities;

namespace Application.Helpers
{
    public static class AccordionMapper
    {
        public static List<SectionAccordionModel> MapToSectionAccordionModel(IEnumerable<AccordionEntity> entities)
        {
            return entities.Select(d => new SectionAccordionModel
            {
                Id = d.Id.ToString(),  // Convert Id to string
                Image = d.Image,
                Label = d.Label,
                Description = d.Description,
                Content = d.Content,
                Type = d.Type
            }).ToList();
        }
    }
}
