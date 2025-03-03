namespace Services.Models
{
    public class SectionAccordionModel
    {
        public string Id { get; set; } = "";
        public string Image { get; set; } = "";
        public string Label { get; set; } = "";
        public string Description { get; set; } = "";
        public string Content { get; set; } = "";
        public string Type { get; set; } = "";  // Column to distinguish between Education and Experience

    }

    public class AccordionModel
    {
        public List<SectionAccordionModel> Education { get; set; } = [];
        public List<SectionAccordionModel> Experience { get; set; } = [];

        /// <summary>
        /// Checks if both Education and Experience lists are empty.
        /// </summary>
        /// <returns>True if both lists are empty, otherwise false.</returns>
        public bool IsEmpty() =>
            Education.Count == 0 && Experience.Count == 0;
    }
}
