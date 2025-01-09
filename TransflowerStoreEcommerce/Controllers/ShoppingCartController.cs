using System.Diagnostics;
using System.Collections.Generic;
using ShoppingCart;
using Microsoft.AspNetCore.Mvc;
using TransflowerStoreWeb.Models;
using BLL;
using Catelog;

namespace TransflowerStoreWeb.Controllers;

public class ShoppingCartController : Controller
{
    private readonly ILogger<ShoppingCartController> _logger;

    public ShoppingCartController(ILogger<ShoppingCartController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Item> items = CartBLLManager.getAllItems();
        ViewData["allItems"] = items;
        return View();
    }

    public IActionResult Details(int id)
    {
        Item item=CartBLLManager.getItemById(id);
        ViewData["ItemById"]=item;
        return View();
    }

    public IActionResult Insert(int id)
    {
        Product product=ProductBLLManager.getProductByID(id);
        return View(product);
    }

    [HttpPost]
    public IActionResult Insert(int id, string title, int customerid, double unitPrice, int quantity)
    {
        
        Product product=new Product
        {
            ProductId=id,
            ProductName=title,
            UnitPrice=unitPrice
        };
        Item item = new Item(product,quantity,customerid);
        bool status = CartBLLManager.insertCart(item);
        if (status)
        {
            return RedirectToAction("Index", "Products");
        }
        else
        {
            return RedirectToAction("Insert", "customer");
        }

    }


    public IActionResult Delete(int id)
    {
        bool status = CartBLLManager.deleteItemById(id);
        if (status)
        {
            Console.WriteLine("cart item delete succesfully");
        }
        return RedirectToAction("Index","ShoppingCart");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
