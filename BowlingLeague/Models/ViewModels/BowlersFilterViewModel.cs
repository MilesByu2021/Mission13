using System;
using System.Collections.Generic;

namespace BowlingLeague.Models
{
    public class BowlersFilterViewModel : Bowlers
    {
        public IEnumerable<Bowlers> Bowlers { get; set; }

        public int CurrentTeam { get; set; }
    }
}
