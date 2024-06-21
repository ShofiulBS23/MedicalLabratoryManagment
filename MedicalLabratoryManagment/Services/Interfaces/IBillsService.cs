using MedicalLabratoryManagment.Models;

namespace MedicalLabratoryManagment.Services.Interfaces;
public interface IBillsService
{
    Task<Bill> GetBillAsync(int billNo);
    Task<IEnumerable<Bill>> GetAllBillsAsync();
    Task<Bill> AddBillAsync(Bill bill);
    Task UpdateBillAsync(Bill bill);
    Task DeleteBillAsync(int billNo);
}
