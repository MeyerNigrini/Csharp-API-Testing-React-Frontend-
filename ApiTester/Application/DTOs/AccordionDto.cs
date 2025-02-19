using ApiTester.Domain.Models;

namespace ApiTester.Application.DTOs
{
    public class AccordionDto
    {
        public List<AccordionModel> Education { get; set; } = [];
        public List<AccordionModel> Experience { get; set; } = [];

        /// <summary>
        /// Checks if both Education and Experience lists are empty.
        /// </summary>
        /// <returns>True if both lists are empty, otherwise false.</returns>
        public bool IsEmpty() =>
            Education.Count == 0 && Experience.Count == 0;
    }
}
