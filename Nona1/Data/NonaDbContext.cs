using Microsoft.EntityFrameworkCore;
using Nona1.Models;

namespace Nona1.Data
{
    public class NonaDbContext : DbContext
    {
        public NonaDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Collab> Collabs { get; set; }
        public DbSet<Item> Items { get; set; }


    }
}
