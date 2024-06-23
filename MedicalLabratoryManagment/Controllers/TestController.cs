using MedicalLabratoryManagment.Models;
using MedicalLabratoryManagment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalLabratoryManagment.Controllers;
public class TestController : Controller
{
    private readonly ITestService _testService;

    public TestController(ITestService testService)
    {
        _testService = testService;
    }

    public IActionResult Index()
    {
        return View();
    }


    [HttpGet]
    public async Task<ActionResult<Test>> GetTest(int id)
    {
        var test = await _testService.GetTestByIdAsync(id);
        if (test == null) return NotFound();
        return test;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Test>>> GetAllTests()
    {
        var tests = await _testService.GetAllTestsAsync();
        return Ok(tests);
    }

    [HttpPost]
    public async Task<ActionResult<Test>> CreateTest([FromBody] Test test)
    {
        var createdTest = await _testService.AddTestAsync(test);
        return CreatedAtAction(nameof(GetTest), new { id = createdTest.TestID }, createdTest);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTest([FromBody] Test test)
    {
        if (test.TestID == 0)
            return BadRequest("In valid operation");

        await _testService.UpdateTestAsync(test);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTest(int id)
    {
        await _testService.DeleteTestAsync(id);
        return NoContent();
    }
}
