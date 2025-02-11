using ApiTester.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ApiTester.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AccordionModel> Data { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Experience> Experience { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Education>().ToTable("Education");
            modelBuilder.Entity<Experience>().ToTable("Experience");

            // Set up foreign key relationships
            modelBuilder.Entity<Education>()
                .HasOne<AccordionModel>()
                .WithOne()
                .HasForeignKey<Education>(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Experience>()
                .HasOne<AccordionModel>()
                .WithOne()
                .HasForeignKey<Experience>(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}