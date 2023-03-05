using Microsoft.EntityFrameworkCore;
using test_student_API.Models;

namespace test_student_API.Data
{
    public class FullStackDbContext : DbContext
    {
        public FullStackDbContext(DbContextOptions options) : base(options)
        {

        }

        //create table in database
        public DbSet<Student> Students { get; set; }
    }
}
