using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public class ContactMeEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Message { get; set; } = "";
    }
}
