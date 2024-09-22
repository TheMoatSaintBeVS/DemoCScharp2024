using System;
using System.Collections.Generic;

namespace DemoAPI.Models
{
    public class Meme
    {
        public int Id { get; set; }
        public string TopText { get; set; }
        public string BottomText { get; set; }
        public bool Public { get; set; }
        public Image Image { get; set; }    
        // FK
        public int ImageId { get; set; }
        public List<MemeTag> MemeTags { get; set; }
    
        public Meme()
        {
          
            MemeTags = new List<MemeTag>();
        }

    }
}
