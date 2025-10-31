using Eproject2025.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eproject2025.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly OnlineBookStoreContext _context;
        public CategoryController(OnlineBookStoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult ViewSubCategory(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _context.Categories
                .Include(c => c.SubCategories)
                .FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            ViewBag.CategoryName = category.CategoryName;
            return View(category.SubCategories.ToList());
        }

    }
}
