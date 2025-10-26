using Gym.Web.Models;

namespace Gym.Web.Services;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> GetAllPaymentsAsync();
    Task<Payment?> GetPaymentByIdAsync(long id);
    Task<Payment> CreatePaymentAsync(Payment payment);
    Task<Payment> UpdatePaymentAsync(Payment payment);
    Task<bool> DeletePaymentAsync(long id);
    Task<IEnumerable<Payment>> GetPaymentsByClientIdAsync(long clientId);
    Task<IEnumerable<Payment>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate);
}
