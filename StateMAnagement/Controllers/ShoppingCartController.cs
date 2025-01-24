//  we have to create index method to create session
//add method of get to get flower by id return view
//at http post menthod open form to get new quantity
//set session for add method
//get session data at index call

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
          var cart=SessionHelper.GetObjectFromSession<Cart>(HttpContext.Session,"cart");
          ViewData["CartItems"] =cart;
          return View();

// for item
        // var item = SessionHelper.GetObjectFromSession<Item>(HttpContext.Session, "cart");
        // ViewData["CartItems"] = item;
        // return View();
    }

    [HttpGet]
    public IActionResult Add(int id)
    {
        Flower flower=  _flowerService.getFlowerById(id);
        ViewData["FolwerById"]=flower;
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

        //SessionHelper.SetJsonObject(HttpContext.Session,"cart",item);


        Cart cart=SessionHelper.GetObjectFromSession<Cart>(HttpContext.Session,"cart");
        cart.Items.Add(item);
        SessionHelper.SetJsonObject(HttpContext.Session, "cart", cart);











        // for item
        // SessionHelper.SetJsonObject(HttpContext.Session, "cart", item);

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
