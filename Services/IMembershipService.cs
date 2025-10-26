using Gym.Web.Models;

namespace Gym.Web.Services;

public interface IMembershipService
{
    Task<IEnumerable<Membership>> GetAllMembershipsAsync();
    Task<Membership?> GetMembershipByIdAsync(long id);
    Task<Membership> CreateMembershipAsync(Membership membership);
    Task<Membership> UpdateMembershipAsync(Membership membership);
    Task<bool> DeleteMembershipAsync(long id);
    Task<IEnumerable<Membership>> GetActiveMembershipsAsync();
    Task<IEnumerable<Membership>> GetMembershipsByClientIdAsync(long clientId);
    Task<IEnumerable<Membership>> GetExpiringMembershipsAsync(int daysAhead = 7);
}
