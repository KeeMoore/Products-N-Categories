using Products_N_Categories.Context;
using Products_N_Categories.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Products_N_Categories.Controllers;

public class ProductsController : Controller
{
    private readonly ApplicationContext _context;

    public ProductsController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet("products")]
    public ViewResult Products()
    {
        var products = _context.Products.ToList();
        var productsPageViewModel = new ProductsPageViewModel()
        {
            Product = new Product(),
            Products = products,
        };

        return View("Products", productsPageViewModel);
    }

    [HttpPost("products/create")]
    public IActionResult CreateProduct(Product newProduct)
    {
        if (!ModelState.IsValid)
        {
            var products = _context.Products.ToList();
            var productsPageViewModel = new ProductsPageViewModel()
            {
                Product = new Product(),
                Products = products,
            };

            return View("Products", productsPageViewModel);
        }
        _context.Products.Add(newProduct);
        _context.SaveChanges();
        return RedirectToAction("Products");
    }
}


