using Microsoft.EntityFrameworkCore;

namespace Homework3.Models
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public UniversityContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
