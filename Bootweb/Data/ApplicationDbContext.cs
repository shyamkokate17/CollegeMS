using CollegePortal.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegePortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }

        public DbSet<Register> Registers { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}
