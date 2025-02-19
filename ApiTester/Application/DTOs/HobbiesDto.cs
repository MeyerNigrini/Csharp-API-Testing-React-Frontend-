using ApiTester.Domain.Models;

namespace ApiTester.Application.DTOs
{
    public class SectionDto
    {
        public string Title { get; set; } = "";
        public List<KeyValuePairModel> Details { get; set; } = [];
        public string Paragraph { get; set; } = "";

        //Helper method to check if the section is empty
        public bool IsEmpty() =>
            string.IsNullOrWhiteSpace(Title) &&
            string.IsNullOrWhiteSpace(Paragraph) &&
            (Details == null || Details.Count==0);

    }

    public class HobbiesDto
    {
        public SectionDto Karate { get; set; } = new SectionDto();
        public SectionDto Gaming { get; set; } = new SectionDto();

        // Helper method to check if the entire DTO is empty
        public bool IsEmpty() =>
            Karate.IsEmpty() && Gaming.IsEmpty();
    }
}
