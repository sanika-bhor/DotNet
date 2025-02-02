using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using paymentProcessingDemo.Models;
using paymentProcessingDemo.Service.Interface;

namespace paymentProcessingDemo.Controllers;

public class HomeController : Controller
{
    private readonly IPaymentService _paymentService;

    public HomeController(IPaymentService service)
    {
       _paymentService=service;
    }

    public IActionResult Index()
    {
        List<Payment> payments=_paymentService.GetAllPayment();
        ViewData["AllPayment"]=payments;
        return View();
    }

    public IActionResult GetById(int id)
    {
        Payment pay=_paymentService.GetElementById(id);
        ViewData["getPayment"]=pay;
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
