namespace IllyCake.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    using IllyCake.Data;
    using IllyCake.Data.Models;
    using IllyCake.Data.Repository;
    using IllyCake.Web.Models;
    using IllyCake.Common.Settings;

    public class HomeController : BaseController
    {
        public HomeController(ApplicationDbContext contex, AppSettings appSettings) : base(contex, appSettings)
        {
        }

        public IActionResult Index()
        {
            //TestCreateDb();
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
        
        private void TestCreateDb()
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
        }
    }
}
