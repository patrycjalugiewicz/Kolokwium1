using Kolokwium.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers;
[ApiController]
[Route("api[controller]")]
public class CustomersController:ControllerBase
{
    public readonly _Service _service;

    public CustomersController(_Service service)
    {
        _service = service;
    }

    [HttpGet("{id}/purchases")]
    public async Task<IActionResult> GetPurchases(int id)
    {
        try
        {
            return Ok(await _service.getCustomerPurchases(id));
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
    }
}