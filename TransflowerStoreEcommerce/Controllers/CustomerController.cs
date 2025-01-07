using System.Diagnostics;
using System.Collections.Generic;
using CRM;
using Microsoft.AspNetCore.Mvc;
using TransflowerStoreWeb.Models;
using BLL;

namespace TransflowerStoreWeb.Controllers;

public class CustomerController : Controller
{
    private readonly ILogger<CustomerController> _logger;

    public CustomerController(ILogger<CustomerController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Customer> customer = CustomerBLLManager.getAllProducts();
        ViewData["allCustomers"] = customer;
        return View();
    }

    public IActionResult Details(int id)
    {
        Customer customer = CustomerBLLManager.getProductByID(id);
        ViewData["customerById"] = customer;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
