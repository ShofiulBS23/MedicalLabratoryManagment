using MedicalLabratoryManagment.Models;

namespace MedicalLabratoryManagment.Services.Interfaces;

public interface IResultService
{
    IEnumerable<Bill> GetAllResults();
    void UpdateResult(Bill result);
    Task<IEnumerable<Bill>> SearchBillsAsync(string query);
}
