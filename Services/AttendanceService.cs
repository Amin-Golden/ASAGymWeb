using Gym.Web.Data;
using Gym.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.Web.Services;

public class AttendanceService : IAttendanceService
{
    private readonly GymDbContext _context;

    public AttendanceService(GymDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Attendance>> GetAllAttendancesAsync()
    {
        return await _context.Attendances
            .Include(a => a.Client)
            .Include(a => a.Session)
            .ThenInclude(s => s.Instructor)
            .Include(a => a.Session)
            .ThenInclude(s => s.Membership)
            .ThenInclude(m => m.Package)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }

    public async Task<Attendance?> GetAttendanceByIdAsync(long id)
    {
        return await _context.Attendances
            .Include(a => a.Client)
            .Include(a => a.Session)
            .ThenInclude(s => s.Instructor)
            .Include(a => a.Session)
            .ThenInclude(s => s.Membership)
            .ThenInclude(m => m.Package)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Attendance> CreateAttendanceAsync(Attendance attendance)
    {
        attendance.CreatedAt = DateTime.UtcNow;
        attendance.UpdatedAt = DateTime.UtcNow;
        
        _context.Attendances.Add(attendance);
        await _context.SaveChangesAsync();
        return attendance;
    }

    public async Task<Attendance> UpdateAttendanceAsync(Attendance attendance)
    {
        attendance.UpdatedAt = DateTime.UtcNow;
        
        _context.Attendances.Update(attendance);
        await _context.SaveChangesAsync();
        return attendance;
    }

    public async Task<bool> DeleteAttendanceAsync(long id)
    {
        var attendance = await _context.Attendances.FindAsync(id);
        if (attendance == null) return false;

        _context.Attendances.Remove(attendance);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Attendance>> GetAttendancesByClientIdAsync(long clientId)
    {
        return await _context.Attendances
            .Where(a => a.ClientId == clientId)
            .Include(a => a.Session)
            .ThenInclude(s => s.Instructor)
            .Include(a => a.Session)
            .ThenInclude(s => s.Membership)
            .ThenInclude(m => m.Package)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Attendance>> GetAttendancesBySessionIdAsync(long sessionId)
    {
        return await _context.Attendances
            .Where(a => a.SessionId == sessionId)
            .Include(a => a.Client)
            .Include(a => a.Session)
            .ThenInclude(s => s.Instructor)
            .OrderBy(a => a.CreatedAt)
            .ToListAsync();
    }

    public async Task<IEnumerable<Attendance>> GetAttendancesByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.Attendances
            .Where(a => a.CreatedAt >= startDate && a.CreatedAt <= endDate)
            .Include(a => a.Client)
            .Include(a => a.Session)
            .ThenInclude(s => s.Instructor)
            .Include(a => a.Session)
            .ThenInclude(s => s.Membership)
            .ThenInclude(m => m.Package)
            .OrderByDescending(a => a.CreatedAt)
            .ToListAsync();
    }
}
