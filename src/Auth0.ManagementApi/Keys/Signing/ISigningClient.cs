using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Keys;

public partial interface ISigningClient
{
    /// <summary>
    /// Retrieve details of all the application signing keys associated with your tenant.
    /// </summary>
    WithRawResponseTask<IEnumerable<SigningKeys>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Rotate the application signing key of your tenant.
    /// </summary>
    WithRawResponseTask<RotateSigningKeysResponseContent> RotateAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details of the application signing key with the given ID.
    /// </summary>
    WithRawResponseTask<GetSigningKeysResponseContent> GetAsync(
        string kid,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Revoke the application signing key with the given ID.
    /// </summary>
    WithRawResponseTask<RevokedSigningKeysResponseContent> RevokeAsync(
        string kid,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
