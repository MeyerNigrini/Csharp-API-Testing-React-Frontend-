namespace ApiTester.Models
{

    public class Section
    {
        public List<KeyValuePairModel> Details { get; set; }
        public string Paragraph { get; set; }
        public string Title { get; set; }
    }

    public class HobbiesModel
    {
        public Section Karate { get; set; }
        public Section Gaming { get; set; }
    }
}
