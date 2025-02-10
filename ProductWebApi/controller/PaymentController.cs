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

        [HttpGet("api/getPaymentById/{id}")]
        public IActionResult GetPaymentById(int id)
        {
            try
            {
                var payment=_srv.GetPaymentById(id);
                if(payment==null)
                {
                    return BadRequest();
                }
                return Ok(payment);
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete("api/delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                 bool status=_srv.Delete(id);
                 if(status)
                 {
                    return Ok("delete sucessfully");
                 }
                 else
                 {
                    return BadRequest();
                 }
            }
            catch(Exception e)
            {
                 return BadRequest();
            }

        }

    }


   
}
