
using Microsoft.EntityFrameworkCore;
using NetCoreApp_Course.Core;

namespace NetCoreApp_Course
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}