using Gym.Web.Data;
using Gym.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.Web.Services;

public class MembershipService : IMembershipService
{
    private readonly GymDbContext _context;

    public MembershipService(GymDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Membership>> GetAllMembershipsAsync()
    {
        return await _context.Memberships
            .Include(m => m.Client)
            .Include(m => m.Package)
            .Include(m => m.Instructor)
            .OrderByDescending(m => m.CreatedAt)
            .ToListAsync();
    }

    public async Task<Membership?> GetMembershipByIdAsync(long id)
    {
        return await _context.Memberships
            .Include(m => m.Client)
            .Include(m => m.Package)
            .Include(m => m.Instructor)
            .Include(m => m.Sessions)
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<Membership> CreateMembershipAsync(Membership membership)
    {
        membership.CreatedAt = DateTime.UtcNow;
        membership.UpdatedAt = DateTime.UtcNow;
        
        _context.Memberships.Add(membership);
        await _context.SaveChangesAsync();
        return membership;
    }

    public async Task<Membership> UpdateMembershipAsync(Membership membership)
    {
        membership.UpdatedAt = DateTime.UtcNow;
        
        _context.Memberships.Update(membership);
        await _context.SaveChangesAsync();
        return membership;
    }

    public async Task<bool> DeleteMembershipAsync(long id)
    {
        var membership = await _context.Memberships.FindAsync(id);
        if (membership == null) return false;

        _context.Memberships.Remove(membership);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Membership>> GetActiveMembershipsAsync()
    {
        var today = DateTime.Today;
        
        return await _context.Memberships
            .Where(m => m.IsPaid && m.EndDate >= today)
            .Include(m => m.Client)
            .Include(m => m.Package)
            .Include(m => m.Instructor)
            .OrderBy(m => m.EndDate)
            .ToListAsync();
    }

    public async Task<IEnumerable<Membership>> GetMembershipsByClientIdAsync(long clientId)
    {
        return await _context.Memberships
            .Where(m => m.ClientId == clientId)
            .Include(m => m.Package)
            .Include(m => m.Instructor)
            .Include(m => m.Sessions)
            .OrderByDescending(m => m.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Membership>> GetExpiringMembershipsAsync(int daysAhead = 7)
    {
        var targetDate = DateTime.Today.AddDays(daysAhead);
        
        return await _context.Memberships
            .Where(m => m.IsPaid && 
                       m.EndDate >= DateTime.Today && 
                       m.EndDate <= targetDate)
            .Include(m => m.Client)
            .Include(m => m.Package)
            .Include(m => m.Instructor)
            .OrderBy(m => m.EndDate)
            .ToListAsync();
    }
}
