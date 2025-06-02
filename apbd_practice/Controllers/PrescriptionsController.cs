using apbd_practice.DTOs;
using apbd_practice.Exceptions;
using apbd_practice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apbd_practice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionsController : ControllerBase
{
    private  readonly IDbService _dbService;

    public PrescriptionsController(IDbService db)
    {
        this._dbService = db;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] PrescriptionDto prescription)
    {
        try
        {
            await _dbService.AddPrescription(prescription);
            return Ok();
        }
        catch (PatientNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (MedicamentNotExistsException exception)
        {
            return NotFound(exception.Message);
        }
        catch (MedicamentOverflowException exception)
        {
            return BadRequest(exception.Message);
        }
        catch (DueDateBeforeDateException exception)
        {
            return BadRequest(exception.Message);
        }
    }
}

