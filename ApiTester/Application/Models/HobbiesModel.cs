using ApiTester.Domain.Entities;

namespace ApiTester.Application.Models
{
    public class SectionModel
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

    public class HobbiesModel
    {
        public SectionModel Karate { get; set; } = new SectionModel();
        public SectionModel Gaming { get; set; } = new SectionModel();

        // Helper method to check if the entire DTO is empty
        public bool IsEmpty() =>
            Karate.IsEmpty() && Gaming.IsEmpty();
    }
}
