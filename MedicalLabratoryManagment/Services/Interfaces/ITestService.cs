using MedicalLabratoryManagment.Models;

namespace MedicalLabratoryManagment.Services.Interfaces;

public interface ITestService
{
    Task<Test> GetTestByIdAsync(int testId);
    Task<IEnumerable<Test>> GetAllTestsAsync();
    Task<Test> AddTestAsync(Test test);
    Task UpdateTestAsync(Test test);
    Task DeleteTestAsync(int testId);
}
