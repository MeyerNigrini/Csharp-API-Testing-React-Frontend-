using System.ComponentModel.DataAnnotations;

namespace ApiTester.Models
{
    public class AccordionModel
    {
        [Key]
        public string Id { get; set; }
        public string Image { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

    }

    public class Education : AccordionModel { }
    public class Experience : AccordionModel { }

}
