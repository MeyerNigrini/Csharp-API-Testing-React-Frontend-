using System.ComponentModel.DataAnnotations;

namespace ApiTester.Domain.Models
{
    public class AccordionModel
    {
        [Key]
        public string Id { get; set; } = "";
        public string Image { get; set; } = "";
        public string Label { get; set; } = "";
        public string Description { get; set; } = "";
        public string Content { get; set; } = "";
        public string Type { get; set; } = "";  // New column to distinguish between Education and Experience

    }
}
