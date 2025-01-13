using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcMultiThreadingApplication.Models;

namespace MvcMultiThreadingApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Thread theThread = Thread.CurrentThread;
        Console.WriteLine("Index thread id: " + theThread.ManagedThreadId);
        return View();
    }

    public IActionResult Privacy()
    {
        Thread theThread = Thread.CurrentThread;
        Console.WriteLine("Privacy thread id: " + theThread.ManagedThreadId);
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
