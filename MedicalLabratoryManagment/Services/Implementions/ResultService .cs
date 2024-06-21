using MedicalLabratoryManagment.Data;
using MedicalLabratoryManagment.Models;
using MedicalLabratoryManagment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedicalLabratoryManagment.Services.Implementions;

public class ResultService : IResultService
{
    private readonly ApplicationDbContext _context;

    public ResultService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Bill> GetAllResults()
    {
        return _context.Bills.ToList();
    }

    public void UpdateResult(Bill result)
    {
        _context.Entry(result).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public async Task<IEnumerable<Bill>> SearchBillsAsync(string query)
    {
        return await _context.Bills
            .Include(b => b.Patient)
            .Where(b => EF.Functions.Like(b.Patient.PatientName, $"%{query}%"))
            .ToListAsync();
    }
}
