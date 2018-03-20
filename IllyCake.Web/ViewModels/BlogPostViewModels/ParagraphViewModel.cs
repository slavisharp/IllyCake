namespace IllyCake.Web.ViewModels.BlogPostViewModels
{
    using IllyCake.Data.Models;

    public class ParagraphViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string CssClassList { get; set; }

        public ParagraphType LayoutType { get; set; }

        public SpecialContentPosition SpecialContentPosition { get; set; }
        
        public string EmbededVideo { get; set; }

        public ImageFileViewModel Image { get; set; }
    }
}
