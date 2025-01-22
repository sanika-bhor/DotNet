using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QueryStringDemo.Models;

namespace QueryStringDemo.Controllers;

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

    // use URL as:http://localhost:5158/home/querytest?Name=sanika&City=pune&state=maharastra
    public IActionResult QueryTest()
    {
        string name=HttpContext.Request.Query["name"];
        string city=HttpContext.Request.Query["city"];
        string state=HttpContext.Request.Query["state"];
        return Content("this is the querystring test invoked.......\n Name: "+name+"\n City: "+city+"\n State: "+state);
    }

    public IActionResult Student()
    {
        List<string> student=new List<string>();
        student.Add("sanika");
        student.Add("sumit");
        student.Add("Ajinkya");
        student.Add("Mansi");

        var allstudent=student.ToArray();

        return new JsonResult(allstudent);
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
