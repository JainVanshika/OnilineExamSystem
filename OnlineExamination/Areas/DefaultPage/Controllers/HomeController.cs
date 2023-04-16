using Microsoft.AspNetCore.Mvc;

namespace OnlineExamination.Areas.DefaultPage.Controllers
{
    public class HomeController : Controller
    {
        [Area("DefaultPage")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
