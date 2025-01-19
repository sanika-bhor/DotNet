using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DIWebApp.Models;
using DIWebApp.Services;

namespace DIWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHomeControllerService _service;

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }
    public HomeController(IHomeControllerService service)
    {
        this._service=service;
    }

    public IActionResult Index()
    {
        string msg=_service.sayHello();
        ViewData["message"]=msg;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
