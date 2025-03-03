using Services.Models;  // Importing the application layer models used for mapping
using Infrastructure.Entities;     // Importing the domain layer entities (data coming from the database)

namespace Services.Mappers  // Defining the namespace where this helper class resides
{
    /// <summary>
    /// A static helper class responsible for mapping domain entities (AccordionEntity) 
    /// to application models (SectionAccordionModel).
    /// This helps separate concerns and ensures that domain entities are not exposed directly 
    /// in the application layer.
    /// </summary>
    public static class AccordionMapper
    {
        /// <summary>
        /// Maps a collection of AccordionEntity objects to a list of SectionAccordionModel objects.
        /// This is useful when transforming data from the database layer into a format that the 
        /// application layer can use, such as for API responses.
        /// </summary>
        /// <param name="entities">A collection of AccordionEntity objects fetched from the database.</param>
        /// <returns>A list of SectionAccordionModel objects containing transformed data.</returns>
        public static List<SectionAccordionModel> MapToSectionAccordionModel(IEnumerable<AccordionEntity> entities)
        {
            // Using LINQ to project each AccordionEntity into a SectionAccordionModel
            return entities.Select(d => new SectionAccordionModel
            {
                Id = d.Id.ToString(),
                Image = d.Image,
                Label = d.Label,
                Description = d.Description,
                Content = d.Content,
                Type = d.Type
            }).ToList();  // Convert the IEnumerable result into a List
        }
    }
}
