using Microsoft.AspNetCore.Mvc;

namespace EFCoreSQLiteDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}