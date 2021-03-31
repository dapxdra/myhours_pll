using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyHours.Entities;

namespace MyHours.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(DbContextOptions<DataContext> options)
        {
            
        }

        //-protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
            // connect to sql server database
         //   options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
       // }

        public DbSet<User> Users { get; set; }
    }
}