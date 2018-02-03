namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Settings;
    using IllyCake.Data.Models;
    using IllyCake.Web.Areas.Admin.ViewModels.HomeViewModels;
    using IllyCake.Web.Services;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    public class HomeController : AdminController
    {
        private IEmailService emailService;

        public HomeController(AppSettings appSettings, UserManager<ApplicationUser> userManager, IEmailService emailService) : base(appSettings, userManager)
        {
            this.emailService = emailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Email()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Email(EmailViewModel input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await this.emailService.SendActionResultEmailAsync(input.RecieverEmail, input.Subject, "Home/About", null);
                    await this.emailService.SendEmailAsync(input.RecieverEmail, input.Subject, input.Body);
                    TempData["success"] = "Имейла е изпратен!";
                }
                else
                {
                    return View(input);
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            
            return RedirectToAction("Email");
        }
    }
}