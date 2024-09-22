using System;
using System.Collections.Generic;

namespace Memes.Entities
{
    public class Meme
    {
        public int Id { get; set; }
        public string TopText { get; set; }
        public string BottomText { get; set; }
        public bool Public { get; set; }
        public User User { get; set; }
        // FK
        public int UserId { get; set; }
        public Image Image { get; set; }
        // FK
        public int ImageId { get; set; }
        public List<MemeTag> MemeTags { get; set; }
        public List<UpVote> UpVotes { get; set; }
        public Meme()
        {
            UpVotes = new List<UpVote>();
            MemeTags = new List<MemeTag>();
        }

    }
}
