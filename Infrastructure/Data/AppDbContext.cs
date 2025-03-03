using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    /// <summary>
    /// Database context class for the application, managing entity configurations and database interactions.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Constructor for AppDbContext, accepting database context options to configure the context
        /// </summary>
        /// <param name="options">Database context options.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet properties representing tables in the database.
        public DbSet<AccordionEntity> AccordionData { get; set; } // Table for storing accordion data.
        public DbSet<InfoEntity> TableData { get; set; } // Table for storing general info data.
        public DbSet<ContactMeEntity> ContactMe { get; set; } // Table for contact details.
        public DbSet<HobbiesEntity> Hobbies { get; set; } // Table for storing hobbies.
        public DbSet<HobbiesDetailEntity> HobbiesDetails { get; set; } // Table for storing details of hobbies.
        public DbSet<UserEntity> Users { get; set; } // Table for storing user data.

        /// <summary>
        /// Configures the model relationships and table mappings.
        /// </summary>
        /// <param name="modelBuilder">Model builder instance used to configure entity relationships.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Table Mappings
            modelBuilder.Entity<AccordionEntity>().ToTable("AccordionData");
            modelBuilder.Entity<InfoEntity>().ToTable("TableData");
            modelBuilder.Entity<ContactMeEntity>().ToTable("ContactMe");
            modelBuilder.Entity<UserEntity>().ToTable("Users");
            modelBuilder.Entity<HobbiesEntity>().ToTable("Hobbies");
            modelBuilder.Entity<HobbiesDetailEntity>().ToTable("HobbiesDetails");

            // Define the foreign key relationship between AccordionEntity and UserEntity
            modelBuilder.Entity<AccordionEntity>()
                .HasOne(a => a.User) // Navigation property to UserEntity
                .WithMany(u => u.Accordions) // A User has many Accordions
                .HasForeignKey(a => a.UserId) // Foreign key in AccordionEntity
                .OnDelete(DeleteBehavior.Cascade);

            // Define the foreign key relationship between HobbiesEntity and UserEntity
            modelBuilder.Entity<HobbiesEntity>()
                .HasOne(h => h.User) // Navigation property to UserEntity
                .WithMany(u => u.Hobbies) // A User has many Hobbies
                .HasForeignKey(h => h.UserId) // Foreign key in HobbiesEntity
                .OnDelete(DeleteBehavior.Cascade);

            // Define the foreign key relationship between InfoEntity and UserEntity
            modelBuilder.Entity<InfoEntity>()
                .HasOne(i => i.User) // Navigation property to UserEntity
                .WithMany(u => u.Infos) // A User has many Infos
                .HasForeignKey(i => i.UserId) // Foreign key in InfoEntity
                .OnDelete(DeleteBehavior.Cascade);

            // Define the foreign key relationship between HobbiesDetailEntity and HobbiesEntity
            modelBuilder.Entity<HobbiesDetailEntity>()
                .HasOne(d => d.Hobby) // Navigation property to HobbiesEntity
                .WithMany(h => h.Details) // A Hobby has many Details
                .HasForeignKey(d => d.HobbyId) // Foreign key in HobbiesDetailEntity
                .OnDelete(DeleteBehavior.Cascade);

            // Call the SeedData class
            SeedData.Seed(modelBuilder);
        }
    }
}
