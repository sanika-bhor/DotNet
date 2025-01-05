using System.Diagnostics;
using System.Collections.Generic;
using Catelog;
using Microsoft.AspNetCore.Mvc;
using TransflowerStoreWeb.Models;

namespace TransflowerStoreWeb.Controllers;

public class ProductsController : Controller
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Product> products = new List<Product>();
        products.Add(new Product(1,"rose","valentine flower",5,4562));
        products.Add(new Product(2, "Gerbera", "merrage flower", 7, 655));
        products.Add(new Product(3, "lotus", "beautiful flower", 13, 56));
        products.Add(new Product(4, "mogra", "smelly flower", 2, 6298));
        products.Add(new Product(5, "hibiscus", "red 5 petal flower", 6, 235));

        ViewData["allProducts"] = products;
        return View();
    }


    public IActionResult Details()
    {
        return View();
    }

    public IActionResult Insert()
    {
        return View();
    }

    public IActionResult Update()
    {
        return View();
    }

    public IActionResult Delete()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
