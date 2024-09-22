using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAPI.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public byte[] Img { get; set; }
        public List<Meme> Memes { get; set; }

        public Image()
        {
            Memes = new List<Meme>();
        }
    }
}
