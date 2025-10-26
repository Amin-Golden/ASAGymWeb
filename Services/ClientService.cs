using Gym.Web.Data;
using Gym.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.Web.Services;

public class ClientService : IClientService
{
    private readonly GymDbContext _context;

    public ClientService(GymDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        return await _context.Clients
            .Include(c => c.Memberships)
            .ThenInclude(m => m.Package)
            .Include(c => c.Memberships)
            .ThenInclude(m => m.Instructor)
            .OrderBy(c => c.LastName)
            .ThenBy(c => c.FirstName)
            .ToListAsync();
    }

    public async Task<Client?> GetClientByIdAsync(long id)
    {
        return await _context.Clients
            .Include(c => c.Memberships)
            .ThenInclude(m => m.Package)
            .Include(c => c.Memberships)
            .ThenInclude(m => m.Instructor)
            .Include(c => c.Payments)
            .Include(c => c.GymSessions)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Client> CreateClientAsync(Client client)
    {
        client.CreatedAt = DateTime.UtcNow;
        client.UpdatedAt = DateTime.UtcNow;
        
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<Client> UpdateClientAsync(Client client)
    {
        client.UpdatedAt = DateTime.UtcNow;
        
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<bool> DeleteClientAsync(long id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null) return false;

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Client>> SearchClientsAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetAllClientsAsync();

        return await _context.Clients
            .Where(c => 
                c.FirstName.Contains(searchTerm) ||
                c.LastName!.Contains(searchTerm) ||
                c.PhoneNumber.Contains(searchTerm) ||
                c.SocialNumber.Contains(searchTerm) ||
                c.Email!.Contains(searchTerm))
            .Include(c => c.Memberships)
            .ThenInclude(m => m.Package)
            .Include(c => c.Memberships)
            .ThenInclude(m => m.Instructor)
            .OrderBy(c => c.LastName)
            .ThenBy(c => c.FirstName)
            .ToListAsync();
    }

    public async Task<bool> AssignLockerAsync(long clientId, int lockerNumber)
    {
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

    public async Task<IEnumerable<Client>> GetClientsWithActiveMembershipsAsync()
    {
        var today = DateTime.Today;
        
        return await _context.Clients
            .Where(c => c.Memberships.Any(m => 
                m.IsPaid && 
                m.EndDate >= today))
            .Include(c => c.Memberships.Where(m => 
                m.IsPaid && 
                m.EndDate >= today))
            .ThenInclude(m => m.Package)
            .Include(c => c.Memberships.Where(m => 
                m.IsPaid && 
                m.EndDate >= today))
            .ThenInclude(m => m.Instructor)
            .OrderBy(c => c.LastName)
            .ThenBy(c => c.FirstName)
            .ToListAsync();
    }
}
