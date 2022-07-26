namespace Auth0.ManagementApi.Clients
{
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;
  using Models.Keys;

  public interface IKeysClient
  {
    /// <summary>
    /// Get all Application Signing Keys
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>All available signing keys <see cref="Key" />.</returns>
    Task<IList<Key>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get an Application Signing Key by its key ID.
    /// </summary>
    /// <param name="kid">The ID of the key to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="Key"/> that was requested.</returns>
    Task<Key> GetAsync(string kid, CancellationToken cancellationToken = default);

    /// <summary>
    /// Rotate the Application Signing Key.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The next rotated key's cert and kid.</returns>
    Task<RotateSigningKeyResponse> RotateSigningKeyAsync( CancellationToken cancellationToken = default);

    /// <summary>
    /// Revoke an Application Signing Key by its key ID.
    /// </summary>
    /// <param name="kid">The ID of the key to revoke.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The revoked key's cert and kid.</returns>
    Task<RevokeSigningKeyResponse> RevokeSigningKeyAsync(string kid, CancellationToken cancellationToken = default);
  }
}
