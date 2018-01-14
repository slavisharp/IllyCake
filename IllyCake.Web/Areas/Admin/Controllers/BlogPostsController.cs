namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Exeptions;
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Data;
    using IllyCake.Data.Models;
    using IllyCake.Web.Areas.Admin.ViewModels.BlogViewModels;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System;
    using System.Linq;
    using System.Net;
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
        [ValidateAntiForgeryToken]
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
        public IActionResult Edit(string id, string tab = "tab-2")
        {
            var vm = this.manager.GetQueryById(id).Select(BlogPostEditViewModel.ExpressionFromBlogPost).FirstOrDefault();
            if (vm == null)
            {
                return NotFound("Публикацията не е намерена");
            }

            ViewBag.ActiveTab = tab;
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BlogPostEditViewModel input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = await this.manager.UpdateBlogPost(input);
                    base.SetActionSuccessMessageInTempData("Информацията за публикацията е обновена.");
                    return RedirectToAction("Edit", new { id = input.Id });
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    return RedirectToAction("Edit", new { id = input.Id });
                }
            }
            else
            {
                ViewBag.ActiveTab = "tab-1";
                IQueryable<Paragraph> paragraphs = this.manager.GetParagraphsForBlog(input.Id);
                input.Paragraphs = paragraphs.Select(ParagraphEditViewModel.ExpressionFromParagraph).OrderBy(p => p.Position).ToList();
                return View(input);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateParagraph(string blogId)
        {
            try
            {
                Paragraph entity = await this.manager.CreateBlankParagraph(blogId);
                return PartialView("_ParagraphPartial", new ParagraphEditViewModel(entity));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateParagraph(ParagraphEditViewModel input)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await this.manager.UpdateParagraph(input);
                    return Json(new { success = "Секция е обновен!" });
                }
                catch (EntityNotFoundException ex)
                {
                    return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
                }
                catch (Exception ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            else
            {
                return BadRequest(string.Join(Environment.NewLine, (ModelState.GetErrorsList())));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteParagraph(int id)
        {
            try
            {
                await this.manager.DeleteParagraph(id);
                return Json(new { success = "Секция е изтрита!" });
            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}