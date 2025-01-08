using System.Diagnostics;
using System.Collections.Generic;
using ShoppingCart;
using Microsoft.AspNetCore.Mvc;
using TransflowerStoreWeb.Models;
using BLL;

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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
