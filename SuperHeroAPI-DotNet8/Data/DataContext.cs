using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Entities;

namespace SuperHeroAPI_DotNet8.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base (options)
        {
            
        }

        //put class/ table name
        public DbSet<SuperHero> SuperHeros { get; set; }

    }
}
