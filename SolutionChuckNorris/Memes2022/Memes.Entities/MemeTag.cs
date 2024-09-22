using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memes.Entities
{
    public  class MemeTag
    {
        public int MemeId { get; set; }
        public Meme Meme { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
