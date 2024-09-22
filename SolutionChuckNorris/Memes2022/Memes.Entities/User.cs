using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memes.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }

        public int Points { get; set; }

        public List<Meme> Memes { get; set; }



        public List<UpVote> UpVotes { get; set; }

        
          
            public User()
        {
            Memes = new List<Meme>();
            UpVotes = new List<UpVote>();
        }

    }
}
