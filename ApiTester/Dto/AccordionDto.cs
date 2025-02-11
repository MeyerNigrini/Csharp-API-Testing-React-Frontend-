using ApiTester.Models;

namespace ApiTester.Dto
{
    public class AccordionDto
    {
        public List<Education> Education { get; set; } = new List<Education>();
        public List<Experience> Experience { get; set; } = new List<Experience>();
    }
}
