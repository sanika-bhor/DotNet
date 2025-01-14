using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using customRouteApp.Models;
using System.Runtime.CompilerServices;

namespace customRouteApp.Controllers;

public class FarmController : Controller
{
    private readonly ILogger<FarmController> _logger;

    public FarmController(ILogger<FarmController> logger)
    {
        _logger = logger;
    }

    public IActionResult getGreenHouseDetails(string FarmName, string FarmNo)
    {
        Console.WriteLine("Farm Name: "+FarmName);
        Console.WriteLine("Farm No: "+FarmNo);
        return View();
    }

    public IActionResult getCropDetails(string FarmName, string FarmNo,string cropId)
    {
        Console.WriteLine("Farm Name: " + FarmName);
        Console.WriteLine("Farm No: " + FarmNo);
        Console.WriteLine("Crop id: " + cropId);
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
