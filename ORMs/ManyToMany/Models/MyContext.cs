using Microsoft.EntityFrameworkCore;

namespace ManyToMany.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options){}
    }
}