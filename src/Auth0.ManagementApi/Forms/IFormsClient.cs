using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IFormsClient
{
    Task<Pager<FormSummary>> ListAsync(
        ListFormsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CreateFormResponseContent> CreateAsync(
        CreateFormRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetFormResponseContent> GetAsync(
        string id,
        GetFormRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<UpdateFormResponseContent> UpdateAsync(
        string id,
        UpdateFormRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
