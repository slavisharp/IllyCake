namespace IllyCake.Web.Controllers
{
    using IllyCake.Data;
    using IllyCake.Data.Models;
    using IllyCake.Data.Repository;
    using IllyCake.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Diagnostics;

    public class HomeController : BaseController
    {
        public HomeController(ApplicationDbContext contex) : base(contex)
        {
        }

        public IActionResult Index()
        {
            var repo = new Repository<Cake>(base.dbContext);
            var entity = new Cake()
            {
                Created = DateTime.Now,
                DeletedOn = null,
                Description = "First Cake",
                IsDeleted = false,
                Modified = DateTime.Now,
                Name = "First Cake"
            };
            repo.Add(entity);
            repo.Save();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
