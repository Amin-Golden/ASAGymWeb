using Gym.Web.Data;
using Gym.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.Web.Services;

public class InstructorService : IInstructorService
{
    private readonly GymDbContext _context;

    public InstructorService(GymDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Instructor>> GetAllInstructorsAsync()
    {
        return await _context.Instructors
            .Include(i => i.Package)
            .Include(i => i.Memberships)
            .ThenInclude(m => m.Client)
            .OrderBy(i => i.LastName)
            .ThenBy(i => i.FirstName)
            .ToListAsync();
    }

    public async Task<Instructor?> GetInstructorByIdAsync(long id)
    {
        return await _context.Instructors
            .Include(i => i.Package)
            .Include(i => i.Memberships)
            .ThenInclude(m => m.Client)
            .Include(i => i.Sessions)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Instructor> CreateInstructorAsync(Instructor instructor)
    {
        instructor.CreatedAt = DateTime.UtcNow;
        instructor.UpdatedAt = DateTime.UtcNow;
        
        _context.Instructors.Add(instructor);
        await _context.SaveChangesAsync();
        return instructor;
    }

    public async Task<Instructor> UpdateInstructorAsync(Instructor instructor)
    {
        instructor.UpdatedAt = DateTime.UtcNow;
        
        _context.Instructors.Update(instructor);
        await _context.SaveChangesAsync();
        return instructor;
    }

    public async Task<bool> DeleteInstructorAsync(long id)
    {
        var instructor = await _context.Instructors.FindAsync(id);
        if (instructor == null) return false;

        _context.Instructors.Remove(instructor);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Instructor>> SearchInstructorsAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetAllInstructorsAsync();

        return await _context.Instructors
            .Where(i => 
                i.FirstName.Contains(searchTerm) ||
                i.LastName!.Contains(searchTerm) ||
                i.PhoneNumber.Contains(searchTerm) ||
                i.Email!.Contains(searchTerm) ||
                i.Title.Contains(searchTerm))
            .Include(i => i.Package)
            .Include(i => i.Memberships)
            .ThenInclude(m => m.Client)
            .OrderBy(i => i.LastName)
            .ThenBy(i => i.FirstName)
            .ToListAsync();
    }

    public async Task<IEnumerable<Instructor>> GetInstructorsByPackageIdAsync(long packageId)
    {
        return await _context.Instructors
            .Where(i => i.PackageId == packageId)
            .Include(i => i.Package)
            .Include(i => i.Memberships)
            .ThenInclude(m => m.Client)
            .OrderBy(i => i.LastName)
            .ThenBy(i => i.FirstName)
            .ToListAsync();
    }
}
