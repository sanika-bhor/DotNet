using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using customRouteApp.Models;

namespace customRouteApp.Controllers;

public class FarmController : Controller
{
    private readonly ILogger<FarmController> _logger;

    public FarmController(ILogger<FarmController> logger)
    {
        _logger = logger;
    }

    public IActionResult getGreenHouseDetails()
    {
        return View();
    }

    public IActionResult getCropDetails()
    {
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
