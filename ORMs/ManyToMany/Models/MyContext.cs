using Microsoft.EntityFrameworkCore;

namespace ManyToMany.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<HeroOnTeam> HeroesOnTeam { get; set; }
    }
}