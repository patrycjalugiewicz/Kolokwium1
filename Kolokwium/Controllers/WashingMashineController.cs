using Kolokwium.DTOs;
using Kolokwium.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers;
[ApiController]
[Route("washing-maschines")]
public class WashingMashineController:ControllerBase
{
    public readonly _Service _service;

    public WashingMashineController(_Service service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> addWashingMaschine(AddWashingMashineDto dto)
    {
        try
        {
            await _service.addWashingMachine(dto);
            return Ok();
        }
        catch (NullReferenceException ex)
        {
            return NotFound(ex.Message);
        }
        catch (AlreadyExists ex)
        {
            return Conflict(ex.Message);
        }
    }
}