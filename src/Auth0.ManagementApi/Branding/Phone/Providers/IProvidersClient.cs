using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Branding.Phone;

public partial interface IProvidersClient
{
    /// <summary>
    /// Retrieve a list of <see href="https://auth0.com/docs/customize/phone-messages/configure-phone-messaging-providers">phone providers</see> details set for a Tenant. A list of fields to include or exclude may also be specified.
    /// </summary>
    WithRawResponseTask<ListBrandingPhoneProvidersResponseContent> ListAsync(
        ListBrandingPhoneProvidersRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a <see href="https://auth0.com/docs/customize/phone-messages/configure-phone-messaging-providers">phone provider</see>.
    /// The <c>credentials</c> object requires different properties depending on the phone provider (which is specified using the <c>name</c> property).
    /// </summary>
    WithRawResponseTask<CreateBrandingPhoneProviderResponseContent> CreateAsync(
        CreateBrandingPhoneProviderRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve <see href="https://auth0.com/docs/customize/phone-messages/configure-phone-messaging-providers">phone provider</see> details. A list of fields to include or exclude may also be specified.
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
    /// Update a <see href="https://auth0.com/docs/customize/phone-messages/configure-phone-messaging-providers">phone provider</see>.
    /// The <c>credentials</c> object requires different properties depending on the phone provider (which is specified using the <c>name</c> property).
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
