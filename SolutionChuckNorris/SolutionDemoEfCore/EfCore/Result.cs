using System;
using System.Collections.Generic;

namespace EfCore
{
    public partial class Result
    {
        public int AthleteId { get; set; }
        public int WorldChampionShipId { get; set; }
        public int? Rank { get; set; }

        public virtual Athete Athlete { get; set; } = null!;
        public virtual WorldChampionShip WorldChampionShip { get; set; } = null!;
    }
}
