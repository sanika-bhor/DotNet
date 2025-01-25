using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Model.Flower;
using Model.Cart;
using Service.Interface;
using SessionHelpers;
using StateMAnagement.Models;

namespace StateMAnagement.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IFlowerService _flowerService;

    public ShoppingCartController(IFlowerService flowerService)
    {
        _flowerService = flowerService;
    }

    public IActionResult Index()
    {
          Cart cart=SessionHelper.GetObjectFromSession<Cart>(HttpContext.Session,"cart");
            if (cart == null)
            {
                cart = new Cart();
                cart.Items = new List<Item>();
            }
        ViewData["CartItems"] =cart.Items;
          return View();

    }

    [HttpGet]
    public IActionResult Add(int id)
    {

        var flower = _flowerService.getFlowerById(id);
        if (flower == null)
        {
            return NotFound("Flower not found.");
        }

        ViewData["FlowerById"] = flower;
        return View();
    }

    [HttpPost]
        public IActionResult Add(int flowerId,string flowerName, int quantity)
        {
            Item item=new Item
            {
                FlowerId= flowerId,
                FlowerName=flowerName,
                Quantity=quantity
            };

    // for cart
            Cart  cart =SessionHelper.GetObjectFromSession<Cart>(HttpContext.Session,"cart");
            if(cart==null)
            {
                cart=new Cart();
                cart.Items=new List<Item>();
            }
            cart.Items.Add(item);
            SessionHelper.SetJsonObject(HttpContext.Session, "cart", cart);

            return RedirectToAction("Index", "Shoppingcart");
        }

    public IActionResult remove(int id)
    {
        Cart cart = SessionHelper.GetObjectFromSession<Cart>(HttpContext.Session, "cart");
        var found = cart.Items.Find(x => x.FlowerId == id);
        if (found != null)
        {
            cart.Items.Remove(found);
        }
        SessionHelper.SetJsonObject(HttpContext.Session, "cart", cart);
        return RedirectToAction("Index", "Shoppingcart");

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
