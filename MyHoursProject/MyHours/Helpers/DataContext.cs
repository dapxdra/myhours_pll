using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyHours.Entities;

namespace MyHours.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext (DbContextOptions<DataContext> options):base(options)
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        // {
        //     // connect to postgresql server database
        //     options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        // }

        public DbSet<User> Users { get; set; }
    }
}