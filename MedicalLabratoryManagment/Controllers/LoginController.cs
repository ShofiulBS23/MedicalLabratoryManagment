using MedicalLabratoryManagment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalLabratoryManagment.Controllers;

public class LoginController : Controller
{
    private readonly IAuthService _authService;

    public LoginController(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string username, string password, string userType)
    {
        var resultUserType = await _authService.AuthenticateUser(username, password, userType);
        if (resultUserType != null) {
            return Ok($"Login Successful as {resultUserType}");
        }
        return Unauthorized("Invalid username or password or user type mismatch.");
    }
}

