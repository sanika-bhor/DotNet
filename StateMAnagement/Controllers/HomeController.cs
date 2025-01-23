using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Model.Flower;
using Service.Interface;
using SessionHelpers;
using StateMAnagement.Models;

namespace StateMAnagement.Controllers;

public class HomeController : Controller
{
    private readonly IFlowerService _flowerService;

    public HomeController(IFlowerService flowerService)
    {
       _flowerService=flowerService;
    }

    public IActionResult Index()
    {
        List<Flower> flowers=_flowerService.getAllFlowers();
        ViewData["allFlowers"]=flowers;
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
