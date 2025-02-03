namespace ApiTester.Models
{
    public class AccordionData
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }        
    }

    public class DetailsModel
    {
        public List<AccordionData> Education { get; set; }
        public List<AccordionData> Experience { get; set; }
        public List<KeyValuePairModel> Info { get; set; }
        public List<KeyValuePairModel> Skills { get; set; }
    }
}
