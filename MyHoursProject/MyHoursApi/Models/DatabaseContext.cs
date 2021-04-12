using Microsoft.EntityFrameworkCore;
namespace MyHoursApi.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<User> Users {get; set;}
        public DbSet<Project> Projects {get; set;}
        public DbSet<Relation> Relations {get; set;}
    }
}