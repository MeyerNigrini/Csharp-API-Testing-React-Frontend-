using System.ComponentModel.DataAnnotations;


namespace Infrastructure.Entities
{
    public class AccordionEntity
    {
        [Key]
        public string Id { get; set; } = "";
        public int UserId { get; set; } // Foreign key to User Entity
        public string Image { get; set; } = "";
        public string Label { get; set; } = "";
        public string Description { get; set; } = "";
        public string Content { get; set; } = "";
        public string Type { get; set; } = "";  // New column to distinguish between Education and Experience


        // Navigation property for UserEntity
        public UserEntity User { get; set; }
    }
}
