using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Branding.Phone;

public partial interface IProvidersClient
{
    /// <summary>
    /// Retrieve a list of <a href="https://auth0.com/docs/customize/phone-messages/configure-phone-messaging-providers">phone providers</a> details set for a Tenant. A list of fields to include or exclude may also be specified.
    /// </summary>
    WithRawResponseTask<ListBrandingPhoneProvidersResponseContent> ListAsync(
        ListBrandingPhoneProvidersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a <a href="https://auth0.com/docs/customize/phone-messages/configure-phone-messaging-providers">phone provider</a>.
    /// The <code>credentials</code> object requires different properties depending on the phone provider (which is specified using the <code>name</code> property).
    /// </summary>
    WithRawResponseTask<CreateBrandingPhoneProviderResponseContent> CreateAsync(
        CreateBrandingPhoneProviderRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve <a href="https://auth0.com/docs/customize/phone-messages/configure-phone-messaging-providers">phone provider</a> details. A list of fields to include or exclude may also be specified.
    /// </summary>
    WithRawResponseTask<GetBrandingPhoneProviderResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete the configured phone provider.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a <a href="https://auth0.com/docs/customize/phone-messages/configure-phone-messaging-providers">phone provider</a>.
    /// The <code>credentials</code> object requires different properties depending on the phone provider (which is specified using the <code>name</code> property).
    /// </summary>
    WithRawResponseTask<UpdateBrandingPhoneProviderResponseContent> UpdateAsync(
        string id,
        UpdateBrandingPhoneProviderRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CreatePhoneProviderSendTestResponseContent> TestAsync(
        string id,
        CreatePhoneProviderSendTestRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
