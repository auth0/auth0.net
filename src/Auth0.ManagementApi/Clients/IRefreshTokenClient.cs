using System.Threading;
using System.Threading.Tasks;

using Auth0.ManagementApi.Models.RefreshTokens;

namespace Auth0.ManagementApi.Clients;

public interface IRefreshTokenClient
{
    /// <summary>
    /// Retrieve refresh token information.
    /// </summary>
    /// <param name="request"><see cref="RefreshTokenGetRequest"/></param>
    /// <param name="cancellationToken"> <see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task<RefreshTokenInformation> GetAsync(RefreshTokenGetRequest request, CancellationToken cancellationToken = default);
        
    /// <summary>
    /// Delete a refresh token by its Id.
    /// </summary>
    /// <param name="id">Id of the refresh token to delete.</param>
    /// <param name="cancellationToken"> <see cref="CancellationToken"/></param>
    /// <returns></returns>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);
}