using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memes.Entities
{
    public class DemoStatic
    {
        public int Id { get; set; }

        public static int GetId()
        {
            return 1;
        }

    }
}
