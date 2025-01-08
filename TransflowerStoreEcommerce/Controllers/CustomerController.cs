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
        List<Customer> customer = CustomerBLLManager.getAllCustomers();
        ViewData["allCustomers"] = customer;
        return View();
    }

    [HttpGet]
    public IActionResult Insert()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Insert(int id, string loginid, string password, string name, string email, string contact, string location)
    {
        Customer customer = new Customer
        {
           CustomerId=id,
           LoginId = loginid,
           Password = password,
           CustomerName = name,
           Email = email,
           ContactNo = contact,
           Location = location
        };

        bool status = CustomerBLLManager.insertCustomer(customer);
        if (status)
        {
            return RedirectToAction("Index", "Customer");
        }
        else
        {
            return RedirectToAction("Insert", "Customer");
        }

    }
    public IActionResult Details(int id)
    {
        Customer customer = CustomerBLLManager.getCustomerByID(id);
        ViewData["customerById"] = customer;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
