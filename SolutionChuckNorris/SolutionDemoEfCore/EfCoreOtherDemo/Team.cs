using System;
using System.Collections.Generic;

namespace EfCoreOtherDemo
{
    public partial class Team
    {
        public Team()
        {
            Athetes = new HashSet<Athete>();
        }

        public int Id { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<Athete> Athetes { get; set; }
    }
}
