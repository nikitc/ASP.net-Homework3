using Microsoft.EntityFrameworkCore;

namespace Homework3.Models
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<RecordBook> RecordBooks { get; set; }

        public UniversityContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RecordBook>()
                .Property(r => r.Number)
                .IsRequired();
        }
    }
}
