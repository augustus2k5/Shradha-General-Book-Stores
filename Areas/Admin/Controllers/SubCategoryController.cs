using Eproject2025.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eproject2025.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly OnlineBookStoreContext _context;
        public SubCategoryController(OnlineBookStoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
