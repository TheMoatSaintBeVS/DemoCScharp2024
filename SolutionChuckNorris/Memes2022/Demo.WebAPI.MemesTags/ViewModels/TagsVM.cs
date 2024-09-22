namespace Demo.WebAPI.MemesTags.ViewModels
{
    public class TagVM
    {
        public int Id { get; set; }
    
        public string Description { get; set; }

        public List<string> Memes { get; set; }

        public TagVM()
        {
            Memes = new List<string>();
        }
    }
}
