using MedicalLabratoryManagment.Data;
using MedicalLabratoryManagment.Models;
using MedicalLabratoryManagment.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace MedicalLabratoryManagment.Services.Implementions;

public class TestService : ITestService
{
    private readonly ApplicationDbContext _context;

    public TestService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Test> GetTestByIdAsync(int testId)
    {
        return await _context.Tests.FindAsync(testId);
    }

    public async Task<IEnumerable<Test>> GetAllTestsAsync()
    {
        return await _context.Tests.ToListAsync();
    }

    public async Task<Test> AddTestAsync(Test test)
    {
        _context.Tests.Add(test);
        await _context.SaveChangesAsync();
        return test;
    }

    public async Task UpdateTestAsync(Test test)
    {
        _context.Entry(test).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTestAsync(int testId)
    {
        var test = await GetTestByIdAsync(testId);
        if (test != null) {
            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();
        }
    }
}

