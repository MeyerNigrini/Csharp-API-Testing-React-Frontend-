using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Hashed password

        // Navigation properties for related entities
        public ICollection<AccordionEntity> Accordions { get; set; }
        public ICollection<InfoEntity> Infos { get; set; }
        public ICollection<HobbiesEntity> Hobbies { get; set; }
    }
}
