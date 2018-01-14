namespace IllyCake.Common.Managers
{
    using IllyCake.Data.Models;

    public interface IUpdateBlogPost : ICreateBlogPost
    {
        string Id { get; set; }

        BlogPostStates State { get; set; }
        
        string MetaDescription { get; set; }
        
        string MetaKeyWords { get; set; }

        bool ShowOnHomePage { get; set; }
    }
}
