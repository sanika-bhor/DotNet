using System.Diagnostics;
using Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    // private readonly ILogger<HomeController> _logger;

    private readonly IFlowerService _flowerService;

    // public HomeController(ILogger<HomeController> logger)
    // {
    //     _logger = logger;
    // }

    public HomeController(IFlowerService flowerService)
    {
        this._flowerService=flowerService;
    }

    public IActionResult Index()
    {
        ViewData["allFlowers"]=_flowerService.GetAllFlowers();
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
