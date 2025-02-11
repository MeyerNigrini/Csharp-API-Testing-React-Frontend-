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
        public DbSet<KeyValuePairModel> InfoData { get; set; }
        public DbSet<Info> Info { get; set; }
        public DbSet<Skills> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Accordion Data
            modelBuilder.Entity<Education>().ToTable("Education");
            modelBuilder.Entity<Experience>().ToTable("Experience");

            // Info Data
            modelBuilder.Entity<Info>().ToTable("Info");
            modelBuilder.Entity<Skills>().ToTable("Skills");

            // Accordion foreign key relationships
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

            // Info foreign key relationships
            modelBuilder.Entity<Info>()
                .HasOne<KeyValuePairModel>()
                .WithOne()
                .HasForeignKey<Info>(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Skills>()
                .HasOne<KeyValuePairModel>()
                .WithOne()
                .HasForeignKey<Skills>(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}