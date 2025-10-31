using Microsoft.AspNetCore.Mvc;

namespace Eproject2025.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
