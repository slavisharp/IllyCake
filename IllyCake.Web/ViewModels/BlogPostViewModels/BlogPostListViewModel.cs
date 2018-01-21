namespace IllyCake.Web.ViewModels.BlogPostViewModels
{
    public class BlogPostListViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Alias { get; set; }

        public string Subtitle { get; set; }

        public string ShortDescription { get; set; }

        public string EmbededVideo { get; set; }

        public ImageFileViewModel Image { get; set; }
    }
}
