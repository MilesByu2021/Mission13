using System;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowlers> Bowlers { get; }

    }
}
