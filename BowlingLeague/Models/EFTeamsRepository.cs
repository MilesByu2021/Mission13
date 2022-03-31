using System;
using System.Linq;

namespace BowlingLeague.Models
{
    public class EFTeamsRepository : ITeamsRepository
    {
        private BowlingDbContext _context { get; set; }

        public EFTeamsRepository(BowlingDbContext temp)
        {
            _context = temp;
        }

        public IQueryable<Teams> Teams => _context.Teams;
    }
}
