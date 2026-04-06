using Microsoft.AspNetCore.Mvc;
using Razorpay.Api;
using System.Collections.Generic;
using PaymentAppADO.Data;

namespace PaymentAppADO.Controllers
{
    public class PaymentController : Controller
    {
        private readonly DbHelper _db;

        public PaymentController(DbHelper db)
        {
            _db = db;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult CreateOrder()
        

            RazorpayClient client = new RazorpayClient(key, secret);

            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", 1000);
            options.Add("currency", "INR");
            options.Add("receipt", "order_123");

            Order order = client.Order.Create(options);

            ViewBag.OrderId = order["id"].ToString();
            ViewBag.Key = key;

            return View("Checkout");
        }

        [HttpPost]
        public IActionResult Verify(string razorpay_payment_id, string razorpay_order_id)
        {
            _db.SavePayment(razorpay_order_id, razorpay_payment_id, "Success", 500);

            return View("Success");
        }
    }
}