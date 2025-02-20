namespace Domain.Entities;

public class InfoEntity : KeyValuePairModel
{
    public int Id { get; set; }
    public int UserId { get; set; } // Foreign key to User Entity
    public string Type { get; set; }  // Add Type property here

    // Navigation property for UserEntity
    public UserEntity User { get; set; }
}
