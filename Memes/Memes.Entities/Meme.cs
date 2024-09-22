using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace Memes.Entities
{
    public class Meme
    {
        public int Id { get; set; }
        public string TopText { get; set; }
        public string BottomText { get; set; }
        public bool Public { get; set; }
        //[ForeignKey("UserId")]
        public int UserId;
        public User User { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }

        public List<Tag> Tags { get; set; }
       public List<User> Users { get; set; }
        public Meme()
        {
            Users = new List<User>();
            Tags = new List<Tag>();
        }

    }
}