using Microsoft.AspNetCore.Mvc;

namespace Shipment.Api.Controllers;
[ApiController]
[Route("api/shipments")]
public class ShipmentController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateShipment(object shipment)
    {
        return Ok("Shipment created");
    }
}