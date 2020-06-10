using Microsoft.EntityFrameworkCore;

namespace CamelBase.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}

        public DbSet<Camel> Camels { get; set; }
    }
}