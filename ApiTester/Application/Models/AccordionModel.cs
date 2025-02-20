using ApiTester.Domain.Models;

namespace ApiTester.Application.DTOs
{
    public class AccordionModel
    {
        public List<AccordionEntity> Education { get; set; } = [];
        public List<AccordionEntity> Experience { get; set; } = [];

        /// <summary>
        /// Checks if both Education and Experience lists are empty.
        /// </summary>
        /// <returns>True if both lists are empty, otherwise false.</returns>
        public bool IsEmpty() =>
            Education.Count == 0 && Experience.Count == 0;
    }
}
