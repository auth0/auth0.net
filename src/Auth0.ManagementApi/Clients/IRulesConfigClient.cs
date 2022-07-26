namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models;

  public interface IRulesConfigClient
  {
    /// <summary>
    /// Creates or updates a rules config variable according to the request.
    /// </summary>
    /// <param name="request">The <see cref="RulesConfigCreateOrUpdateRequest" /> containing the details of the rule to create or update.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The newly created <see cref="Rule" />.</returns>
    Task<RulesConfig> CreateOrUpdateAsync(RulesConfigCreateOrUpdateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a rules config variable.
    /// </summary>
    /// <param name="key">The key of the rules-config to delete.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteAsync(string key, CancellationToken cancellationToken = default);
  }
}
