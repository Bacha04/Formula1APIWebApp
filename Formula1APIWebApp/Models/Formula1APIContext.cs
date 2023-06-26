using Microsoft.EntityFrameworkCore;

namespace Formula1APIWebApp.Models
{
    public class Formula1APIContext : DbContext
    {
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<RaceResult> RaceResults { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Team> Teames { get; set; }

        public Formula1APIContext(DbContextOptions<Formula1APIContext> options) 
          : base(options)

        {
            Database.EnsureCreated();
        }
    }
}
