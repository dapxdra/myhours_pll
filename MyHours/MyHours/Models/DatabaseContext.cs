using Microsoft.EntityFrameworkCore;

namespace MyHours.Models
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<User> Users {get; set;}
    }
}