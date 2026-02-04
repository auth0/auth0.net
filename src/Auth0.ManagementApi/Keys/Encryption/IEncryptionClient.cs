using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Keys;

public partial interface IEncryptionClient
{
    /// <summary>
    /// Retrieve details of all the encryption keys associated with your tenant.
    /// </summary>
    Task<Pager<EncryptionKey>> ListAsync(
        ListEncryptionKeysRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create the new, pre-activated encryption key, without the key material.
    /// </summary>
    WithRawResponseTask<CreateEncryptionKeyResponseContent> CreateAsync(
        CreateEncryptionKeyRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Perform rekeying operation on the key hierarchy.
    /// </summary>
    Task RekeyAsync(RequestOptions? options = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve details of the encryption key with the given ID.
    /// </summary>
    WithRawResponseTask<GetEncryptionKeyResponseContent> GetAsync(
        string kid,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Import wrapped key material and activate encryption key.
    /// </summary>
    WithRawResponseTask<ImportEncryptionKeyResponseContent> ImportAsync(
        string kid,
        ImportEncryptionKeyRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete the custom provided encryption key with the given ID and move back to using native encryption key.
    /// </summary>
    Task DeleteAsync(
        string kid,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create the public wrapping key to wrap your own encryption key material.
    /// </summary>
    WithRawResponseTask<CreateEncryptionKeyPublicWrappingResponseContent> CreatePublicWrappingKeyAsync(
        string kid,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
