using System.Diagnostics;
using System.Collections.Generic;
using Catelog;
using Microsoft.AspNetCore.Mvc;
using TransflowerStoreWeb.Models;
using BLL;

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
        List<Product> products = ProductBLLManager.getAllProducts();
        ViewData["allProducts"] = products;
        return View();
    }


    public IActionResult Details(int id)
    {
        Product product=ProductBLLManager.getProductByID(id);
        ViewData["productById"]=product;
        return View();
    }

    [HttpGet]
    public IActionResult Insert()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Insert(int id, string title,string description,double unitPrice, int quantity,string image)
    {
        Product product = new Product
        {
            ProductId=id,
            ProductName=title,
            Description=description,
            UnitPrice=unitPrice,
            Quantity=quantity,
            Image=image
        };

        bool status=ProductBLLManager.insertProduct(product);
        if(status)
        {
            return RedirectToAction("Index","Products");
        }
        else
        {
            return RedirectToAction("Insert", "Products");
        }
      
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        Product product=ProductBLLManager.getProductByID(id);
        return View(product);
    }

    [HttpPost]
    public IActionResult Update(int id, string title, string description, double unitPrice, int quantity, string image)
    {
        Product product = new Product
        {
            ProductId=id,
            ProductName=title,
            Description=description,
            UnitPrice=unitPrice,
            Quantity=quantity,
            Image=image
        };

         ProductBLLManager.updateProduct(product);
        return RedirectToAction("Index", "Products");
        
  }


    public IActionResult Delete(int id)
    {
        bool status=ProductBLLManager.deleteProductById(id);
        if(status)
        {
            Console.WriteLine("Product delete succesfully");
        }
        return RedirectToAction("index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
