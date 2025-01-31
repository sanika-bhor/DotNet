using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BIApp.Models;

namespace BIApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        ViewBag.School="transflower Learning Private Limited";
        return View();
    }

    public IActionResult Services()
    {
        string servicesAvailble="\n 1.fullstack \n 2. frontEnd \n 3.Backend \n 4.AI development";
        TempData["servicesAvailble"]= servicesAvailble;
        return View();
    }

    public IActionResult Contact()
    {
        ViewData["contact"]="bhorsanika029@gmail.com";
        return View();
    }

    public IActionResult Sales()
    {
        SalesRevenueAcessLayer sales=new SalesRevenueAcessLayer();
        return View(sales);
    }

    public IActionResult Privacy()
    {
        return View();
    }

public IActionResult ListProduct()
{
    SalesRevenueAcessLayer srl=new SalesRevenueAcessLayer();
    var product=srl.FillProduct().ToArray();
    return new JsonResult(product);
}


    public IActionResult ListCustomer()
    {
        SalesRevenueAcessLayer srl = new SalesRevenueAcessLayer();
        var customer = srl.FillCustomer().ToArray();
        return new JsonResult(customer);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
