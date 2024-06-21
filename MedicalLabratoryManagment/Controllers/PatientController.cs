using MedicalLabratoryManagment.Models;
using MedicalLabratoryManagment.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalLabratoryManagment.Controllers;

public class PatientController : Controller
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    [HttpPost()]
    public async Task<IActionResult> AddPatient([FromBody] Patient dto)
    {
        try {
            if (dto != null) {
                await _patientService.AddPatientAsync(dto);
                return Ok();
            }
            return BadRequest("Please enter all the information.");
        } catch (Exception ex) {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut()]
    public async Task<IActionResult> UpdatePatient([FromBody] Patient patient)
    {
        try {
            await _patientService.UpdatePatientAsync(patient);
            return Ok();
        } catch (Exception ex) {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("Patient/delete/{id}")]
    public async Task<IActionResult> DeletePatient(int id)
    {
        try {
            await _patientService.DeletePatientAsync(id);
            return Ok();
        } catch (Exception ex) {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("Patient/search/{id}")]
    public async Task<IActionResult> SearchPatient(int id)
    {
        try {
            var patient = await _patientService.SearchPatientAsync(id);
            if (patient != null) {
                return Ok(patient);
            }
            return NotFound();
        } catch (Exception ex) {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpGet("/patient/all")]
    public async Task<IActionResult> GetAllPatients()
    {
        try {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        } catch (Exception ex) {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
        }
    }
}
