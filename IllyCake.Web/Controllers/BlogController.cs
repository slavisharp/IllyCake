namespace IllyCake.Web.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using IllyCake.Web.ViewModels.BlogPostViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class BlogController : BaseController
    {
        private IBlogPostManager blogManager;

        public BlogController(AppSettings settings, UserManager<ApplicationUser> userManager, IBlogPostManager blogManager) : base(settings, userManager)
        {
            this.blogManager = blogManager;
        }

        [HttpGet]
        [Route("blog")]
        public IActionResult Index()
        {
            var vm = this.blogManager
                .GetAllPublished()
                .OrderByDescending(p => p.Created)
                .Select(BlogPostListViewModel.ExpressionFromBlogPost)
                .ToList();

            return View(vm);
        }

        [HttpGet]
        [Route("blog/{alias}")]
        public IActionResult Details(string alias)
        {
            var vm = this.blogManager
                .GetQueryByAlias(alias)
                .Select(BlogPostViewModel.ExpressionDetailsFromBlogPost)
                .FirstOrDefault();

            if (vm == null)
            {
                return NotFound("Публикацията не е намерена!");
            }

            return View(vm);
        }
    }
}