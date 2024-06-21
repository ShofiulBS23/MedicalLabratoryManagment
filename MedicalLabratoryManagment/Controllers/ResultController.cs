using MedicalLabratoryManagment.Models;
using MedicalLabratoryManagment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalLabratoryManagment.Controllers;

public class ResultController : Controller
{
    private readonly IResultService _resultService;

    public ResultController(IResultService resultService)
    {
        _resultService = resultService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Bill>> Get()
    {
        return Ok(_resultService.GetAllResults());
    }

    [HttpPut]
    public IActionResult Update(Bill result)
    {
        _resultService.UpdateResult(result);
        return NoContent();
    }
}

