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
    [HttpGet]
    public IActionResult Insert()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Insert(int Id,int OrderId,double Amount, DateTime PaymentDate, string PaymentMode)
    {
        Payment payment=new Payment
        {
            Id=Id,
            OrderId=OrderId,
            Amount=Amount,
            PaymentDate=PaymentDate,
            PaymentMode=PaymentMode
        };

        bool status=_paymentService.Insert(payment);
        if(status)
        {
           return RedirectToAction("index");
        }
        return View();
    }

[HttpPost]
    public IActionResult Update(int Id, int OrderId, double Amount, DateTime PaymentDate, string PaymentMode)
    {
        Payment payment = new Payment
        {
            Id = Id,
            OrderId = OrderId,
            Amount = Amount,
            PaymentDate = PaymentDate,
            PaymentMode = PaymentMode
        };

        bool status = _paymentService.Update(payment);
        if (status)
        {
            return RedirectToAction("index");
        }
        return View();
    }
[HttpGet]
    public IActionResult Update(int id)
    {
        Payment pay = _paymentService.GetElementById(id);
        ViewData["getPayment"] = pay;
        return View();
    }


    public IActionResult delete(int id)
    {
        bool status = _paymentService.Delete(id);
        if (status)
        {
            return RedirectToAction("index");
        }
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
