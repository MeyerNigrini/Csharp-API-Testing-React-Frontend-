using System.ComponentModel.DataAnnotations;

namespace ApiTester.Domain.Entities
{
    public class HobbiesEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; } // Foreign key to User Entity
        public string Paragraph { get; set; } = "";
        public string Title { get; set; } = "";

        // Navigation property for related HobbyDetails
        public ICollection<HobbiesDetailEntity> Details { get; set; }

        // Navigation property for UserEntity
        public UserEntity User { get; set; }
    }

    public class HobbiesDetailEntity : KeyValuePairModel
    {
        public new int Id { get; set; }
        public int HobbyId { get; set; }  // Foreign key to Hobbies table
        // Navigation property to HobbiesModel
        public HobbiesEntity Hobby { get; set; }
    }
}
