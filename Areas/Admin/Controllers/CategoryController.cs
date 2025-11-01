using Eproject2025.DTOs;
using Eproject2025.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eproject2025.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly OnlineBookStoreContext _context;
        private string GenerateCategoryId()
        {
            var random = new Random();

            // Tạo ký tự đầu là chữ cái A-Z
            char letter = (char)('A' + random.Next(0, 26));

            // Ký tự thứ hai là số 0-9
            int digit = random.Next(0, 10);

            return $"{letter}{digit}";
        }

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

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(CategoryDTO categoryDTO)
        {
            if(!ModelState.IsValid)
            {
                var allErrors = ModelState.Values
        .SelectMany(v => v.Errors)
        .Select(e => e.ErrorMessage)
        .ToList();

                // Gửi lỗi sang View
                ViewBag.ValidationErrors = allErrors;
                return View(categoryDTO);
            }

            string newId;
            do
            {
                newId = GenerateCategoryId();
            }
            while (_context.Categories.Any(c => c.CategoryId == newId));

            var category = new Category
            {
                CategoryId = newId,
                CategoryName = categoryDTO.CategoryName,
                Description = categoryDTO.Description,
                Status = categoryDTO.Status ?? "Active"
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(string id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            var dto = new CategoryDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Status = category.Status
            };
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
                return View(categoryDTO);

            var category = await _context.Categories.FindAsync(categoryDTO.CategoryId);
            if (category == null) return NotFound();

            category.CategoryName = categoryDTO.CategoryName;
            category.Description = categoryDTO.Description;

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> ToggleStatus(string id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return NotFound();

            category.Status = category.Status == "Active" ? "Inactive" : "Active";

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
