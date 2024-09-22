using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memes.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The description is mandatory"),
            MinLength(10, ErrorMessage = "Too short : 10 characters are needed")]
        public string Description { get; set; }

        public List<Meme> Memes { get; set; }   
       
        public Tag()
        {
           Memes= new List<Meme>();
        }
    }
}
