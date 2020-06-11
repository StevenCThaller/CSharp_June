using Microsoft.EntityFrameworkCore;

namespace TwoFormsOnePage.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}
        
        public DbSet<Liquor> Liquors { get; set; }
        public DbSet<Mixer> Mixers { get; set; }
    }
}