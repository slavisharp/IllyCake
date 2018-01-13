namespace IllyCake.Web.Areas.Admin.Controllers
{
    using IllyCake.Common.Settings;
    using IllyCake.Data;
    using IllyCake.Data.Models;
    using IllyCake.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        private const string SUCCESS_TEMP_DATA_KEY = "success";
        private const string ERROR_TEMP_DATA_KEY = "error";
        private const string ERRORS_TEMP_DATA_KEY = "errors";

        public AdminController(AppSettings appSettings, UserManager<ApplicationUser> userManager) : base(appSettings, userManager)
        {

        }

        protected void SetActionSuccessMessageInTempData(string message, bool removeErrors = true)
        {
            TempData[SUCCESS_TEMP_DATA_KEY] = message;
            if (removeErrors)
            {
                TempData[ERROR_TEMP_DATA_KEY] = null;
                TempData[ERRORS_TEMP_DATA_KEY] = null;
            }
        }
    }
}
