namespace Memes.API.Models
{
    public class Meme
    {
        public int Id { get; set; }
        public string TopText { get; set; }
        public string BottomText { get; set; }

        public int UserId { get; set; }
        public string ImageUri { get; set; }
        public Byte[] Image { get; set; }

        public Meme()
        {

        }
    }
}
