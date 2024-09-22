using System;
using System.Collections.Generic;

namespace EfCoreOtherDemo
{
    public partial class WorldChampionShip
    {
        public WorldChampionShip()
        {
            Results = new HashSet<Result>();
        }

        public int Id { get; set; }
        public string? City { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}
