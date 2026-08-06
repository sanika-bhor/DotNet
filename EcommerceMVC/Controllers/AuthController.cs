using EcommerceMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceMVC.Controllers
{
    public class AuthController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(Credential credential)
        {

            if(credential.UserName=="sanika" && credential.Password=="sanika")
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
            return View();
            }
        }
    }
}