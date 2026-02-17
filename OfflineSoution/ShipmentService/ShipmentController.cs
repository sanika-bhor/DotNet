using Microsoft.AspNetCore.Mvc;
using ShipmentEntity;
namespace ShipmentService
{
    [ApiController]
    [Route("[controller]")]
    public class ShipmentController:ControllerBase
    {
        [HttpPost("track")]
        public IActionResult TrackShipment([FromBody] Shipment shipment)
        {
            var trackingInfo = new
            {
                ShipmentId=shipment.ShipmentId,
                Status="In Transit",
                EstimatedDelivery=DateTime.Now.AddDays(3)
            };
            return Ok(trackingInfo);
        }
    }
}