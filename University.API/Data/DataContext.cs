using Microsoft.EntityFrameworkCore;
using University.API.Models;

namespace University.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }

        public DbSet<Address> Address { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Student> Student { get; set; }
    }
}
