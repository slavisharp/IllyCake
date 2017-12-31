namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data;
    using IllyCake.Data.Models;
    using IllyCake.Web.Areas.Admin.ViewModels.BlogViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    public class BlogPostsController : AdminController
    {
        private IBlogPostManager manager;

        public BlogPostsController(AppSettings appSettings, IBlogPostManager manager, UserManager<ApplicationUser> userManager) : base(appSettings, userManager)
        {
            this.manager = manager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var vm = this.manager.GetAll().Select(BlogPostListViewModel.ExpressionFromBlogPost);
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await base.GetCurrentUser();
            var vm = new BlogPostCreateViewModel();
            if (user != null)
            {
                vm.CreatorId = user.Id;
            }

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogPostCreateViewModel input)
        {
            if (ModelState.IsValid)
            {
                var post = await this.manager.CreateBlogPost(input);
                return RedirectToAction(nameof(this.Edit), new { id = post.Id });
            }

            return View(input);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            return View();
        }
    }
}