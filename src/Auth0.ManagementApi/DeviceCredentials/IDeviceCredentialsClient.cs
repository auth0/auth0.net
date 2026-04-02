using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IDeviceCredentialsClient
{
    /// <summary>
    /// Retrieve device credential information (<c>public_key</c>, <c>refresh_token</c>, or <c>rotating_refresh_token</c>) associated with a specific user.
    /// </summary>
    Task<Pager<DeviceCredential>> ListAsync(
        ListDeviceCredentialsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a device credential public key to manage refresh token rotation for a given <c>user_id</c>. Device Credentials APIs are designed for ad-hoc administrative use only and paging is by default enabled for GET requests.
    ///
    /// When refresh token rotation is enabled, the endpoint becomes consistent. For more information, read <see href="https://auth0.com/docs/get-started/tenant-settings/signing-keys"> Signing Keys</see>.
    /// </summary>
    WithRawResponseTask<CreatePublicKeyDeviceCredentialResponseContent> CreatePublicKeyAsync(
        CreatePublicKeyDeviceCredentialRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Permanently delete a device credential (such as a refresh token or public key) with the given ID.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
