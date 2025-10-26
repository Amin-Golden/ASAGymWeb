using Gym.Web.Models;

namespace Gym.Web.Services;

public interface IClientService
{
    Task<IEnumerable<Client>> GetAllClientsAsync();
    Task<Client?> GetClientByIdAsync(long id);
    Task<Client> CreateClientAsync(Client client);
    Task<Client> UpdateClientAsync(Client client);
    Task<bool> DeleteClientAsync(long id);
    Task<IEnumerable<Client>> SearchClientsAsync(string searchTerm);
    Task<bool> AssignLockerAsync(long clientId, int lockerNumber);
    Task<bool> ReleaseLockerAsync(long clientId);
    Task<IEnumerable<Client>> GetClientsWithActiveMembershipsAsync();
}
