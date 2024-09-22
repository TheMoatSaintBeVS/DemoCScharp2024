using System;
using System.Collections.Generic;

namespace EfCore
{
    public partial class Athete
    {
        public Athete()
        {
            Results = new HashSet<Result>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Dob { get; set; }
        public int TeamId { get; set; }

        public virtual Team Team { get; set; } = null!;
        public virtual ICollection<Result> Results { get; set; }
    }
}
