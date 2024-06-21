using MedicalLabratoryManagment.Models;
using MedicalLabratoryManagment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalLabratoryManagment.Controllers;

public class BillController : Controller
{
    private readonly IBillsService _billsService;

    public BillController(IBillsService billsService)
    {
        _billsService = billsService;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    public async Task<IActionResult> GetBill(int billNo)
    {
        var bill = await _billsService.GetBillAsync(billNo);
        if (bill == null) return NotFound();
        return Ok(bill);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBills()
    {
        var bills = await _billsService.GetAllBillsAsync();
        return Ok(bills);
    }

    [HttpPost]
    public async Task<IActionResult> AddBill(Bill bill)
    {
        var createdBill = await _billsService.AddBillAsync(bill);
        return CreatedAtAction(nameof(GetBill), new { billNo = createdBill.BillNo }, createdBill);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBill(int billNo, Bill bill)
    {
        if (billNo != bill.BillNo) return BadRequest("Bill ID mismatch");
        await _billsService.UpdateBillAsync(bill);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteBill(int billNo)
    {
        await _billsService.DeleteBillAsync(billNo);
        return NoContent();
    }
}

