using Microsoft.AspNetCore.Mvc;

namespace MedicalLabratoryManagment.Controllers;

public class MainController : Controller
{
    public MainController()
    {
        
    }
    public IActionResult Index()
    {
        return View();
    }
}
