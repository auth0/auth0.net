using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Branding.Phone;

public partial interface ITemplatesClient
{
    WithRawResponseTask<ListPhoneTemplatesResponseContent> ListAsync(
        ListPhoneTemplatesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CreatePhoneTemplateResponseContent> CreateAsync(
        CreatePhoneTemplateRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetPhoneTemplateResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<UpdatePhoneTemplateResponseContent> UpdateAsync(
        string id,
        UpdatePhoneTemplateRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<ResetPhoneTemplateResponseContent> ResetAsync(
        string id,
        object request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CreatePhoneTemplateTestNotificationResponseContent> TestAsync(
        string id,
        CreatePhoneTemplateTestNotificationRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
