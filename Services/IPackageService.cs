using Gym.Web.Models;

namespace Gym.Web.Services;

public interface IPackageService
{
    Task<IEnumerable<Package>> GetAllPackagesAsync();
    Task<Package?> GetPackageByIdAsync(long id);
    Task<Package> CreatePackageAsync(Package package);
    Task<Package> UpdatePackageAsync(Package package);
    Task<bool> DeletePackageAsync(long id);
    Task<IEnumerable<Package>> SearchPackagesAsync(string searchTerm);
}
