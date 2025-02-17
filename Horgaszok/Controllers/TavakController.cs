using Microsoft.AspNetCore.Mvc;

namespace Horgaszok.Controllers
{
    public class TavakController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
