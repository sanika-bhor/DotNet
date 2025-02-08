using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Model;
using ProductWebApi.Service;

namespace ProductWebApi.Controller
{
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentSevice _srv;

        public PaymentController(IPaymentSevice srv)
        {
            this._srv = srv;
        }

        [HttpGet]
        [Route("api/getPayment")]
        public IActionResult GetPayment()
        {
            try
            {
                var payments = _srv.GetPayments();
                if (payments == null)
                {
                    return NotFound("No payment found.");
                }
                return Ok(payments);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

    }


   
}
