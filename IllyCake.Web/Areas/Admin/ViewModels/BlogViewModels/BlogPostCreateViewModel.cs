namespace IllyCake.Web.Areas.Admin.ViewModels.BlogViewModels
{
    using IllyCake.Common.Managers;

    public class BlogPostCreateViewModel : BlogPostBaseViewModel, ICreateBlogPost
    {
        public string CreatorId { get; set; }
    }
}
