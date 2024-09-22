using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.Models
{
    public class Tag
    {

        public int Id { get; set; }
     
        public string Description { get; set; }

        public List<MemeTag> MemeTags { get; set; }
        public Tag()
        {
            MemeTags = new List<MemeTag>();
        }
    }
}
