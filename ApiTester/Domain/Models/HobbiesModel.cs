using System.ComponentModel.DataAnnotations;

namespace ApiTester.Domain.Models
{
    public class HobbiesModel
    {
        [Key]
        public int Id { get; set; }
        public string Paragraph { get; set; } = "";
        public string Title { get; set; } = "";

        // Navigation property for related HobbyDetails
        public ICollection<HobbiesDetailModel> Details { get; set; } = [];
    }

    public class HobbiesDetailModel : KeyValuePairModel
    {
        public new int Id { get; set; }
        public int HobbyId { get; set; }  // Foreign key to Hobbies table
        // Navigation property to HobbiesModel
        public HobbiesModel Hobby { get; set; } = new();
    }
}
