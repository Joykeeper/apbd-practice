using apbd_practice.DTOs;
using apbd_practice.Exceptions;
using apbd_practice.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apbd_practice.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private  readonly IDbService _dbService;

    public PatientsController(IDbService db)
    {
        this._dbService = db;
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientInfo([FromRoute] int id)
    {
        try
        {
            var patient = await _dbService.GetPatientData(id);
            return Ok(patient);
        }
        catch (PatientNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}