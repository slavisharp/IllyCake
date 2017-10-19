namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Settings;
    using IllyCake.Data;
    using IllyCake.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        public AdminController(AppSettings appSettings) : base(appSettings)
        {

        }
    }
}
