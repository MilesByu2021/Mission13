using System;
using System.Linq;

namespace BowlingLeague.Models
{
    public interface ITeamsRepository
    {
        IQueryable<Teams> Teams { get; }
    }
}
