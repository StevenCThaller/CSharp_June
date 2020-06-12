using Microsoft.EntityFrameworkCore;

namespace OneToMany.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}

        public DbSet<Killer> Killers { get; set; }
        public DbSet<Victim> Victims { get; set; }
    }
}