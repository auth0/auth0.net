namespace Auth0.ManagementApi.Clients
{
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;
  using Models;

  public interface IBlacklistedTokensClient
  {
    /// <summary>
    /// Gets all the blacklisted claims.
    /// </summary>
    /// <param name="aud">The JWT's aud claim. The client_id of the client for which it was issued.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A list of <see cref="BlacklistedToken"/> objects.</returns>
    Task<IList<BlacklistedToken>> GetAllAsync(string aud, CancellationToken cancellationToken = default);

    /// <summary>
    /// Blacklists a JWT token.
    /// </summary>
    /// <param name="request">The <see cref="BlacklistedTokenCreateRequest"/> containing the information of the token to blacklist.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous create operation.</returns>
    Task CreateAsync(BlacklistedTokenCreateRequest request, CancellationToken cancellationToken = default);
  }
}
