using Gym.Web.Models;

namespace Gym.Web.Services;

public interface IAttendanceService
{
    Task<IEnumerable<Attendance>> GetAllAttendancesAsync();
    Task<Attendance?> GetAttendanceByIdAsync(long id);
    Task<Attendance> CreateAttendanceAsync(Attendance attendance);
    Task<Attendance> UpdateAttendanceAsync(Attendance attendance);
    Task<bool> DeleteAttendanceAsync(long id);
    Task<IEnumerable<Attendance>> GetAttendancesByClientIdAsync(long clientId);
    Task<IEnumerable<Attendance>> GetAttendancesBySessionIdAsync(long sessionId);
    Task<IEnumerable<Attendance>> GetAttendancesByDateRangeAsync(DateTime startDate, DateTime endDate);
}
