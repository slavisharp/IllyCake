namespace IllyCake.Web.ViewModels.HomePageViewModels
{
    using IllyCake.Web.Areas.Admin.ViewModels.BlogViewModels;
    using IllyCake.Web.Areas.Admin.ViewModels.ProductViewModels;
    using System.Collections.Generic;

    public class HomePageViewModel
    {
        public IEnumerable<BlogPostListViewModel> BlogPosts { get; set; }

        public IEnumerable<ProductListViewModel> Products { get; set; }
    }
}
