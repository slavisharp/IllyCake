namespace IllyCake.Web.Controllers
{
    using IllyCake.Data;
    using Microsoft.AspNetCore.Mvc;

    public class BaseController : Controller
    {
        protected ApplicationDbContext dbContext;

        public BaseController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }
    }
}