using System;
using System.Linq;

namespace BowlingLeague.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlingDbContext _context { get; set; }

        public EFBowlersRepository(BowlingDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowlers> Bowlers => _context.Bowlers;
    }
}
