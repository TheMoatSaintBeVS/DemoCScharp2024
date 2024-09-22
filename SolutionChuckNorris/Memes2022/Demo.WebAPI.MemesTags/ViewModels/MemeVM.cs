namespace Demo.WebAPI.MemesTags.ViewModels
{
    public class MemeVM
    {
        
            public int Id { get; set; }
            public string TopText { get; set; }
            public string BottomText { get; set; }
            public bool Public { get; set; }
            public string User { get; set; }
         
            public string  Image { get; set; }
           
            public List<string> Tags { get; set; }
            public List<string> UpVoteUsers{ get; set; }
            public MemeVM()
            {
                Tags = new List<string>();
                UpVoteUsers = new List<string>();
            }

        
    }
}
