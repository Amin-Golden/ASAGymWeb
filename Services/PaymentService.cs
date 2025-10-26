using Gym.Web.Data;
using Gym.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.Web.Services;

public class PaymentService : IPaymentService
{
    private readonly GymDbContext _context;

    public PaymentService(GymDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Payment>> GetAllPaymentsAsync()
    {
        return await _context.Payments
            .Include(p => p.Client)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }

    public async Task<Payment?> GetPaymentByIdAsync(long id)
    {
        return await _context.Payments
            .Include(p => p.Client)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Payment> CreatePaymentAsync(Payment payment)
    {
        payment.CreatedAt = DateTime.UtcNow;
        payment.UpdatedAt = DateTime.UtcNow;
        
        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();
        return payment;
    }

    public async Task<Payment> UpdatePaymentAsync(Payment payment)
    {
        payment.UpdatedAt = DateTime.UtcNow;
        
        _context.Payments.Update(payment);
        await _context.SaveChangesAsync();
        return payment;
    }

    public async Task<bool> DeletePaymentAsync(long id)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment == null) return false;

        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByClientIdAsync(long clientId)
    {
        return await _context.Payments
            .Where(p => p.ClientId == clientId)
            .Include(p => p.Client)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Payment>> GetPaymentsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.Payments
            .Where(p => p.CreatedAt >= startDate && p.CreatedAt <= endDate)
            .Include(p => p.Client)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }
}
