using System;
using Microsoft.EntityFrameworkCore;

namespace BowlingLeague.Models
{
    public class BowlingDbContext : DbContext 
    {
        public BowlingDbContext(DbContextOptions<BowlingDbContext> options) : base (options)
        {

        }

        public DbSet<Bowlers> Bowlers { get;  set; }

        public DbSet<Teams> Teams { get; set; }
    }
}
