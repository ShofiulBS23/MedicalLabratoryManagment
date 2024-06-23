using MedicalLabratoryManagment.Data;
using MedicalLabratoryManagment.Models;
using MedicalLabratoryManagment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalLabratoryManagment.Services.Implementions;

public class BillsService : IBillsService
{
    private readonly ApplicationDbContext _context;

    public BillsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Bill> GetBillAsync(int billNo)
    {
        return await _context.Bills.FindAsync(billNo);
    }

    public async Task<IEnumerable<Bill>> GetAllBillsAsync()
    {
        return await _context.Bills.Include(p => p.Patient).ToListAsync();
    }

    public async Task<Bill> AddBillAsync(Bill bill)
    {
        _context.Bills.Add(bill);
        await _context.SaveChangesAsync();
        return bill;
    }

    public async Task UpdateBillAsync(Bill bill)
    {
        _context.Entry(bill).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBillAsync(int billNo)
    {
        var bill = await _context.Bills.FindAsync(billNo);
        if (bill != null) {
            _context.Bills.Remove(bill);
            await _context.SaveChangesAsync();
        }
    }
}

