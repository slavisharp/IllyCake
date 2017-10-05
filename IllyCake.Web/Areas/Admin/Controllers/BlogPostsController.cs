using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IllyCake.Web.Areas.Admin.Controllers
{
    public class BlogPostsController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}