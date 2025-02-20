namespace ApiTester.Domain.Models
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Hashed password

        // Navigation properties for related entities
        public ICollection<AccordionEntity> Accordions { get; set; }
        public ICollection<InfoEntity> Infos { get; set; }
        public ICollection<HobbiesEntity> Hobbies { get; set; }
    }
}
