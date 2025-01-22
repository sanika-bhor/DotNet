using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ConfigurtionSetting.Models;

namespace ConfigurtionSetting.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _configuration;
    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration=configuration;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Connect()
    {
        string connectionString=String.Empty;
        var connection1=_configuration.GetConnectionString("ConnectionStringEcommerce");
         var connection2=_configuration.GetConnectionString("ConnectionStringStudent");
        
         List<string> allconnection=new List<string>();
         allconnection.Add(connection1);
         allconnection.Add(connection2);
        // connectionString=(string) connection1;
        ViewData["connstring"]=allconnection;
        // ViewData["connstring"]=connectionString;
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
