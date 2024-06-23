using MedicalLabratoryManagment.Models;

namespace MedicalLabratoryManagment.Services.Interfaces;

public interface IOrderDetailService
{
    Task<IEnumerable<OrderDetials>> GetAllOrderDetailsAsync();
    Task<OrderDetials> GetOrderDetailByIdAsync(int detailId);
    Task AddOrderDetailAsync(OrderDetials orderDetail);
    Task UpdateOrderDetailAsync(OrderDetials orderDetail);
    Task DeleteOrderDetailAsync(int detailId);
    Task<List<OrderDetials>> GetOrderDetailsByPatientAndBillAsync(int patientId, int billNo);
}
