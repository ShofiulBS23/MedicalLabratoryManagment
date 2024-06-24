using MedicalLabratoryManagment.Models;
using MedicalLabratoryManagment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalLabratoryManagment.Controllers;

public class UserSettingsController : Controller
{
    private readonly IUserSettingsService _service;

    public UserSettingsController(IUserSettingsService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult GetUserSettings(int id)
    {
        var settings = _service.GetUserSettings(id);
        if (settings == null) {
            return NotFound();
        }
        return Ok(settings);
    }

    [HttpGet]
    public IActionResult GetAllUserSettings()
    {
        var settings = _service.GetAllUserSettings();
        return Ok(settings);
    }

    [HttpPut]
    public IActionResult UpdateUserSettings([FromBody] UserModel settings)
    {
        _service.UpdateUserSettings(settings);
        return Ok();
    }

    [HttpPost]
    public IActionResult CreateUserSettings([FromBody] UserModel settings)
    {
        _service.CreateUserSettings(settings);
        return CreatedAtAction(nameof(GetUserSettings), new { id = settings.UserId }, settings);
    }

    [HttpDelete]
    public IActionResult DeleteUserSettings(int id)
    {
        try {
            _service.DeleteUserSettings(id);
            return Ok(new { message = "User settings deleted successfully." });
        } catch (InvalidOperationException ex) {
            // Handle the case where the user was not found or could not be deleted
            return NotFound(new { message = ex.Message });
        } catch (Exception ex) {
            // Handle other possible exceptions
            return StatusCode(500, new { message = "An error occurred while deleting user settings.", error = ex.Message });
        }
    }
}