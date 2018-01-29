namespace IllyCake.Web.ViewModels.HomePageViewModels
{
    using IllyCake.Web.ViewModels.BlogPostViewModels;
    using IllyCake.Web.ViewModels.ProductViewModels;
    using System.Collections.Generic;

    public class HomePageViewModel
    {
        public IList<BlogPostListViewModel> BlogPosts { get; set; }

        public IList<ProductListViewModel> Products { get; set; }
    }
}
