using MedicalLabratoryManagment.Models;
using MedicalLabratoryManagment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        try {
            return View();
        } catch(Exception ex) 
        {
            throw ex;
        }
       
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
    public async Task<IActionResult> AddBill([FromBody] Bill bill)
    {
        if (bill.PatientID != 0) {
            bill.BillDate = DateTime.Now.ToString("yyyy/MM/dd");
            var createdBill = await _billsService.AddBillAsync(bill);
            return Ok(createdBill);
        }
        return BadRequest();
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
        bool success = await _billsService.DeleteBillAndOrderDetailsAsync(billNo);
        if (success)
            return NoContent();
        else
            return NotFound("Bill not found.");
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

    [HttpPost]
    public async Task<IActionResult> UpdateOrderDetailsAndTotalPrice([FromBody] OrderDetials orderDetails)
    {
        await _orderDetailService.AddOrderDetailAsync(orderDetails);
        var bill = await _billsService.GetBillAsync(orderDetails.BillId ?? 0);
        if (bill != null) {
            bill.TotalPrice += orderDetails.Price;
            await _billsService.UpdateBillAsync(bill);
        }
        return Ok();
    }
}

