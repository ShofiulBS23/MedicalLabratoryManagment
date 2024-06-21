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
}