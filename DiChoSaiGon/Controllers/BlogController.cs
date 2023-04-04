using Microsoft.AspNetCore.Mvc;

namespace DiChoSaiGon.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
