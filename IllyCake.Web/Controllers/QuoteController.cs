namespace IllyCake.Web.Controllers
{
    using IllyCake.Common.Managers;
    using IllyCake.Common.Settings;
    using IllyCake.Web.ViewModels.QuoteViewModels;
    using Microsoft.AspNetCore.Mvc;

    public class QuoteController : BaseController
    {
        private IQuoteManager quoteManager;

        public QuoteController(AppSettings appSettings, IQuoteManager quoteManager) : base(appSettings)
        {
            this.quoteManager = quoteManager;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return View(new CreateQuoteViewModel() { Description = "Опишете вашата торта в това поле" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateQuoteViewModel input)
        {

            return RedirectToAction(nameof(this.Details));
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return StatusCode(404);
            }

            return View();
        }
    }
} 