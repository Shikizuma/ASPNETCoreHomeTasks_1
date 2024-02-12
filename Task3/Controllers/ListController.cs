using Microsoft.AspNetCore.Mvc;

namespace Task3.Controllers
{
    public class ListController : Controller
    {
        private readonly ILogger<ListController> _logger;

        public ListController(ILogger<ListController> logger)
        {
            _logger = logger;
        }

        public ActionResult Info()
        {
            return View();
        }
    }
}
