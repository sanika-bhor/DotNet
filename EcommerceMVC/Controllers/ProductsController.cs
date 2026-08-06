using EcommerceMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class ProductsController:Controller
    {
        List<Product> products=new List<Product>()
        {
            new Product(1,"laptop",25000),
            new Product(2,"mobile",2560)
        };
        public IActionResult ListProducts()
        {
            return View(products);
        }


    }
}