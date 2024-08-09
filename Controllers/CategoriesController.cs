#pragma warning disable CS8618
using Products_N_Categories.Context;
using Products_N_Categories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Products_N_Categories.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationContext _context;

        public CategoriesController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("categories")]
        public ViewResult Categories()
        {
            var categories = _context.Categories.ToList();
            var categoriesPageViewModel = new CategoriesPageViewModel()
            {
                Category = new Category(),
                Categories = categories,
            };
            return View("Categories", categoriesPageViewModel);
        }

        [HttpPost("categories/create")]
        public IActionResult CreateCategory(Category newCategory)
        {
            if (!ModelState.IsValid)
            {
                var categories = _context.Categories.ToList();
                var categoriesPageViewModel = new CategoriesPageViewModel()
                {
                    Category = new Category(),
                    Categories = categories,
                };

                return View("Categories", categoriesPageViewModel);
            }

            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Categories");
        }

        [HttpGet("categories/details/{id}")]
        public IActionResult CategoryDetails(int Id)
        {
            var category = _context.Categories
                .Include(c => c.Products)
                // .ThenInclude(cp => cp.Product)
                .FirstOrDefault(c => c.CategoryId == Id);

            if (category == null)
            {
                return NotFound();
            }

            var unassociatedProducts = _context.Products
                .Where(p => !p.Categories.Any(c => c.CategoryId == Id))
                .ToList();

            var viewModel = new CategoryDetailsPageViewModel()
            {
                Category = category,
                Association = new Association()
                {
                    CategoryId = Id
                },
                Products = unassociatedProducts,
            };

            return View("CategoryDetails", viewModel);
        }

        [HttpPost("categories/add-product")]
        public IActionResult AddProductToCategory(int categoryId, int productId)
        {
            var newAssociation = new Association()
            {
                CategoryId = categoryId,
                ProductId = productId,

            };
            _context.Associations.Add(newAssociation);
            _context.SaveChanges();
            return RedirectToAction("CategoryDetails", new { categoryId });
        }
       
    }
}
