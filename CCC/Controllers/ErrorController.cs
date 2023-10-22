using Microsoft.AspNetCore.Mvc;

namespace CCC.UI.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
