using ApiTester.Domain.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiTester.Infrastructure.Data
{
    /// <summary>
    /// Database context class for the application, managing entity configurations and database interactions.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Constructor for AppDbContext, accepting database context options.
        /// </summary>
        /// <param name="options">Database context options.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet properties representing tables in the database.
        public DbSet<AccordionEntity> AccordionData { get; set; } // Table for storing accordion data.
        public DbSet<InfoEntity> TableData { get; set; } // Table for storing general info data.
        public DbSet<ContactMeEntity> ContactMe { get; set; } // Table for contact details.
        public DbSet<HobbiesEntity> Hobbies { get; set; } // Table for storing hobbies.
        public DbSet<HobbiesDetailEntity> HobbiesDetails { get; set; } // Table for storing details of hobbies.

        /// <summary>
        /// Configures the model relationships and table mappings.
        /// </summary>
        /// <param name="modelBuilder">Model builder instance used to configure entity relationships.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapping entities to their respective database tables.

            // Accordion Data Table Mapping
            modelBuilder.Entity<AccordionEntity>().ToTable("AccordionData");

            // Info Data Table Mapping
            modelBuilder.Entity<InfoEntity>().ToTable("TableData");

            // Contact Me Table Mapping
            modelBuilder.Entity<ContactMeEntity>().ToTable("ContactMe");

            // Hobbies Table Mapping with Primary Key
            modelBuilder.Entity<HobbiesEntity>()
                .ToTable("Hobbies")
                .HasKey(x => x.Id);

            // Hobbies Details Table Mapping with Primary Key
            modelBuilder.Entity<HobbiesDetailEntity>()
                .ToTable("HobbiesDetails")
                .HasKey(d => d.Id);

            // Define the foreign key relationship between Hobbies and HobbiesDetails.
            modelBuilder.Entity<HobbiesDetailEntity>()
                .HasOne(d => d.Hobby) // Navigation property to the parent entity (Hobby)
                .WithMany(h => h.Details) // Reverse navigation: A Hobby has many details.
                .HasForeignKey(d => d.HobbyId) // Foreign key in HobbiesDetailModel.
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete: When a hobby is deleted, its details are also removed.
        }
    }
}
