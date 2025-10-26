using Gym.Web.Data;
using Gym.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.Web.Services;

public class LockerService : ILockerService
{
    private readonly GymDbContext _context;
    private const int TotalLockers = 200;

    public LockerService(GymDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<int>> GetAvailableLockersAsync()
    {
        var assignedLockers = await _context.Clients
            .Where(c => c.Locker.HasValue)
            .Select(c => c.Locker!.Value)
            .ToListAsync();

        var allLockers = Enumerable.Range(1, TotalLockers);
        return allLockers.Except(assignedLockers);
    }

    public async Task<IEnumerable<int>> GetAssignedLockersAsync()
    {
        return await _context.Clients
            .Where(c => c.Locker.HasValue)
            .Select(c => c.Locker!.Value)
            .OrderBy(l => l)
            .ToListAsync();
    }

    public async Task<bool> AssignLockerAsync(long clientId, int lockerNumber)
    {
        if (lockerNumber < 1 || lockerNumber > TotalLockers)
            return false;

        var client = await _context.Clients.FindAsync(clientId);
        if (client == null) return false;

        // Check if locker is already assigned
        var existingClient = await _context.Clients
            .FirstOrDefaultAsync(c => c.Locker == lockerNumber);
        
        if (existingClient != null) return false;

        client.Locker = lockerNumber;
        client.UpdatedAt = DateTime.UtcNow;
        
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ReleaseLockerAsync(long clientId)
    {
        var client = await _context.Clients.FindAsync(clientId);
        if (client == null) return false;

        client.Locker = null;
        client.UpdatedAt = DateTime.UtcNow;
        
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<int?> GetClientLockerAsync(long clientId)
    {
        var client = await _context.Clients
            .Where(c => c.Id == clientId)
            .Select(c => c.Locker)
            .FirstOrDefaultAsync();
        
        return client;
    }

    public async Task<int> GetAvailableLockerCountAsync()
    {
        var assignedCount = await _context.Clients
            .CountAsync(c => c.Locker.HasValue);
        
        return TotalLockers - assignedCount;
    }

    public async Task<Dictionary<int, Client?>> GetLockerAssignmentsAsync()
    {
        var assignments = new Dictionary<int, Client?>();
        
        // Initialize all lockers as unassigned
        for (int i = 1; i <= TotalLockers; i++)
        {
            assignments[i] = null;
        }

        // Get assigned lockers
        var assignedLockers = await _context.Clients
            .Where(c => c.Locker.HasValue)
            .Include(c => c.Memberships.Where(m => m.IsPaid && m.EndDate >= DateTime.Today))
            .ToListAsync();

        foreach (var client in assignedLockers)
        {
            if (client.Locker.HasValue)
            {
                assignments[client.Locker.Value] = client;
            }
        }

        return assignments;
    }
}
