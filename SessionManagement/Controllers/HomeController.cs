using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using SessionManagement.Models;

namespace SessionManagement.Controllers;
[Serializable]
public class Cart
{
   public List<string>items=new List<string>();

    public Cart()
    {
        items.Add("mobile");
        items.Add("Laptop");
        items.Add("T.V");
        items.Add("Frige");
    }
    public List<String> getAll()
    {
        return items;
    }
}
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string sessionKeyName="product";
        HttpContext.Session.SetString(sessionKeyName,"Microwave");
        HttpContext.Session.SetInt32("Age",19);

        Cart cartItem = new Cart();
        List<string> items=cartItem.getAll();
        var str=JsonSerializer.Serialize(items);
        HttpContext.Session.SetString("cart", str);

        return View();
    }

    public IActionResult Privacy()
    {
       string product=HttpContext.Session.GetString("product");
        ViewBag.data=product;

        var dataItems=HttpContext.Session.GetString("cart");
       var AllItems=JsonSerializer.Deserialize<List<string>>(dataItems);
        ViewData["cartItems"]=AllItems;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
