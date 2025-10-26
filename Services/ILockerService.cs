using Gym.Web.Models;

namespace Gym.Web.Services;

public interface ILockerService
{
    Task<IEnumerable<int>> GetAvailableLockersAsync();
    Task<IEnumerable<int>> GetAssignedLockersAsync();
    Task<bool> AssignLockerAsync(long clientId, int lockerNumber);
    Task<bool> ReleaseLockerAsync(long clientId);
    Task<int?> GetClientLockerAsync(long clientId);
    Task<int> GetAvailableLockerCountAsync();
    Task<Dictionary<int, Client?>> GetLockerAssignmentsAsync();
}
