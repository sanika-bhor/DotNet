using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BIApp.Models;

namespace BIApp.Controllers;

public class DashboardController : Controller
{

    public JsonResult CityRevenue()
    {
        List<RevenueModel> list=RevenueModelAccessLayer.getCityRevenue();
        return Json(list);
    }

    public JsonResult StateRevenue()
    {
        List<RevenueModel> list = RevenueModelAccessLayer.getStateRevenue();
        return Json(list);
    }

    public IActionResult lineChart()
    {
        return View();
    }

    public IActionResult barChart()
    {
        return View();
    }
    public IActionResult pieChart()
    {
        return View();
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
