namespace Memes.API.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string  Uri { get; set; }
        public byte[]? Img { get; set; }
        public List<Meme> Memes { get; set; }

        public Image(string uri)
        {
            Uri = uri;
            Memes = new List<Meme>();
        }
        public Image(int id, string uri)
        {
          Uri = uri;
            Memes = new List<Meme>();
        }
    }
}
