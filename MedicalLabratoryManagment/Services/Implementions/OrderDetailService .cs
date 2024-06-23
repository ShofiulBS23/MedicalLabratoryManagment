using MedicalLabratoryManagment.Data;
using MedicalLabratoryManagment.Models;
using MedicalLabratoryManagment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalLabratoryManagment.Services.Implementions;

public class OrderDetailService : IOrderDetailService
{
    private readonly ApplicationDbContext _context;

    public OrderDetailService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderDetials>> GetAllOrderDetailsAsync()
    {
        return await _context.OrderDetials.ToListAsync();
    }

    public async Task<OrderDetials> GetOrderDetailByIdAsync(int detailId)
    {
        return await _context.OrderDetials.FirstOrDefaultAsync(od => od.DetailID == detailId);
    }

    public async Task AddOrderDetailAsync(OrderDetials orderDetail)
    {
        if (orderDetail == null)
            throw new ArgumentNullException(nameof(orderDetail));

        _context.OrderDetials.Add(orderDetail);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateOrderDetailAsync(OrderDetials orderDetail)
    {
        if (orderDetail == null)
            throw new ArgumentNullException(nameof(orderDetail));

        _context.Entry(orderDetail).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrderDetailAsync(int detailId)
    {
        var orderDetail = await _context.OrderDetials.FindAsync(detailId);
        if (orderDetail != null) {
            _context.OrderDetials.Remove(orderDetail);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<List<OrderDetials>> GetOrderDetailsByPatientAndBillAsync(int patientId, int billNo)
    {
        return await _context.OrderDetials
            .Where(od => od.PatientID == patientId && od.BillId == billNo).Include(t => t.Test)
            .ToListAsync();
    }
}
