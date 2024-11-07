namespace Auth0.ManagementApi.Clients
{
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;
  using Models.Keys;
  using Paging;

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

    /// <summary>
    /// Retrieve details of all the encryption keys associated with your tenant.
    /// </summary>
    /// <param name="pagination"><see cref="PaginationInfo"/></param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>Retrieve details of all the encryption keys associated with your tenant. <see cref="Auth0.ManagementApi.Models.EncryptionKey" />.</returns>
    Task<IPagedList<EncryptionKey>> GetAllEncryptionKeysAsync(PaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Create the new, pre-activated encryption key, without the key material.
    /// </summary>
    /// <param name="request"><see cref="EncryptionKeyCreateRequest"/></param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>Newly created pre-activated encryption key <see cref="Auth0.ManagementApi.Models.EncryptionKey" />.</returns>
    Task<EncryptionKey> CreateEncryptionKeyAsync(EncryptionKeyCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve details of the encryption key with the given ID.
    /// </summary>
    /// <param name="request"><see cref="EncryptionKeyGetRequest"/></param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>Retrieve details of the encryption key associated with the id. <see cref="Auth0.ManagementApi.Models.EncryptionKey" />.</returns>
    Task<EncryptionKey> GetEncryptionKeyAsync(EncryptionKeyGetRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete the custom provided encryption key with the given ID and move back to using native encryption key.
    /// </summary>
    /// <param name="kid">Encryption key ID</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    Task DeleteEncryptionKeyAsync(string kid, CancellationToken cancellationToken = default);

    /// <summary>
    /// Import wrapped key material and activate encryption key.
    /// </summary>
    /// <param name="request"><see cref="EncryptionKeyImportRequest"/></param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    Task<EncryptionKey> ImportEncryptionKeyAsync(EncryptionKeyImportRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Create the public wrapping key to wrap your own encryption key material.
    /// </summary>
    /// <param name="request"><see cref="WrappingKeyCreateRequest"/></param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    Task<WrappingKey> CreatePublicWrappingKeyAsync(WrappingKeyCreateRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Perform rekeying operation on the key hierarchy.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    Task RekeyAsync(CancellationToken cancellationToken = default);
  }
}
