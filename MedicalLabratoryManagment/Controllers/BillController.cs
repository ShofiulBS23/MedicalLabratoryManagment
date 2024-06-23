using MedicalLabratoryManagment.Models;
using MedicalLabratoryManagment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalLabratoryManagment.Controllers;

public class BillController : Controller
{
    private readonly IBillsService _billsService;
    private readonly IOrderDetailService _orderDetailService;

    public BillController(
        IBillsService billsService
        , IOrderDetailService orderDetailService)
    {
        _billsService = billsService;
        _orderDetailService = orderDetailService;
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
    [HttpGet]
    public async Task<ActionResult<List<OrderDetials>>> GetOrderDetailsByPatientAndBill(int patientId, int billNo)
    {
        try {
            var orderDetails = await _orderDetailService.GetOrderDetailsByPatientAndBillAsync(patientId, billNo);

            if (orderDetails == null || orderDetails.Count == 0)
                return NotFound(new { Message = "No order details found for the given patient and bill ID." });

            return Ok(orderDetails);
        } catch (System.Exception ex) {
            return StatusCode(500, new { Message = "An error occurred while retrieving order details.", Details = ex.Message });
        }
    }
}

