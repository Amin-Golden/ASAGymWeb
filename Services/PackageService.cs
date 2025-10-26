using Gym.Web.Data;
using Gym.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.Web.Services;

public class PackageService : IPackageService
{
    private readonly GymDbContext _context;

    public PackageService(GymDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Package>> GetAllPackagesAsync()
    {
        return await _context.Packages
            .Include(p => p.Instructors)
            .Include(p => p.Memberships)
            .OrderBy(p => p.PackageName)
            .ToListAsync();
    }

    public async Task<Package?> GetPackageByIdAsync(long id)
    {
        return await _context.Packages
            .Include(p => p.Instructors)
            .Include(p => p.Memberships)
            .ThenInclude(m => m.Client)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Package> CreatePackageAsync(Package package)
    {
        package.CreatedAt = DateTime.UtcNow;
        package.UpdatedAt = DateTime.UtcNow;
        
        _context.Packages.Add(package);
        await _context.SaveChangesAsync();
        return package;
    }

    public async Task<Package> UpdatePackageAsync(Package package)
    {
        package.UpdatedAt = DateTime.UtcNow;
        
        _context.Packages.Update(package);
        await _context.SaveChangesAsync();
        return package;
    }

    public async Task<bool> DeletePackageAsync(long id)
    {
        var package = await _context.Packages.FindAsync(id);
        if (package == null) return false;

        _context.Packages.Remove(package);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Package>> SearchPackagesAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return await GetAllPackagesAsync();

        return await _context.Packages
            .Where(p => 
                p.PackageName.Contains(searchTerm) ||
                p.Description!.Contains(searchTerm) ||
                p.Duration.Contains(searchTerm))
            .Include(p => p.Instructors)
            .Include(p => p.Memberships)
            .OrderBy(p => p.PackageName)
            .ToListAsync();
    }
}
