using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace Infrastructure.Entities;

public class InfoEntity : KeyValuePairModel
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; } // Foreign key to User Entity
    public string Type { get; set; }  // Add Type property here

    // Navigation property for UserEntity
    public UserEntity User { get; set; }
}
