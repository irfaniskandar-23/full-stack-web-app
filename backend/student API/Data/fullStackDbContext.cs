using Microsoft.EntityFrameworkCore;
using student_API.Models;

namespace student_API.Data
{
    public class fullStackDbContext: DbContext
    {
        public fullStackDbContext(DbContextOptions options) : base(options) 
        {
        }

        //create table in database
        public DbSet<Student> Students { get; set; }
    }
}
