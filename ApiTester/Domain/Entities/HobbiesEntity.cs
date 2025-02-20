using System.ComponentModel.DataAnnotations;

namespace ApiTester.Domain.Models
{
    public class HobbiesEntity
    {
        [Key]
        public int Id { get; set; }
        public string Paragraph { get; set; } = "";
        public string Title { get; set; } = "";

        // Navigation property for related HobbyDetails
        public ICollection<HobbiesDetailEntity> Details { get; set; } = [];
    }

    public class HobbiesDetailEntity : KeyValuePairModel
    {
        public new int Id { get; set; }
        public int HobbyId { get; set; }  // Foreign key to Hobbies table
        // Navigation property to HobbiesModel
        public HobbiesEntity Hobby { get; set; } = new();
    }
}
