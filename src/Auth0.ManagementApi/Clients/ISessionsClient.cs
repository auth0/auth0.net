using System.Threading;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models.Sessions;

namespace Auth0.ManagementApi.Clients;

public interface ISessionsClient
{
    /// <summary>
    /// Retrieve session information.
    /// </summary>
    /// <param name="request"><see cref="SessionsGetRequest"/></param>
    /// <param name="cancellationToken"> <see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<Sessions> GetAsync(SessionsGetRequest request, CancellationToken cancellationToken = default);
        
    /// <summary>
    /// Delete a session by Id.
    /// </summary>
    /// <param name="id">Id of the session to delete.</param>
    /// <param name="cancellationToken"> <see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
        
    /// <summary>
    /// Revokes a session by Id and all associated refresh tokens.
    /// </summary>
    /// <param name="id">Id of the session to revoke</param>
    /// <param name="cancellationToken"> <see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task RevokeAsync(string id, CancellationToken cancellationToken = default);
}