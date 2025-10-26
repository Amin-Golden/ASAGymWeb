using Gym.Web.Models;

namespace Gym.Web.Services;

public interface IInstructorService
{
    Task<IEnumerable<Instructor>> GetAllInstructorsAsync();
    Task<Instructor?> GetInstructorByIdAsync(long id);
    Task<Instructor> CreateInstructorAsync(Instructor instructor);
    Task<Instructor> UpdateInstructorAsync(Instructor instructor);
    Task<bool> DeleteInstructorAsync(long id);
    Task<IEnumerable<Instructor>> SearchInstructorsAsync(string searchTerm);
    Task<IEnumerable<Instructor>> GetInstructorsByPackageIdAsync(long packageId);
}
