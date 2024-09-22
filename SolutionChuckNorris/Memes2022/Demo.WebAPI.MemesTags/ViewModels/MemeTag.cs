namespace Demo.WebAPI.MemesTags.ViewModels
{
    public record MemeTagVM
    {
        public int Id { get; set; }

        public string Text { get; set; }
        public string BottomText { get; set; }
        public string TopText { get; set; }
        public int UserId { get; set; }
        public int ImageId { get; set; }
        public  List<TagInfoVM> Tags { get; set; }


    }
}
