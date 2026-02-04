using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.VerifiableCredentials.Verification;

public partial interface ITemplatesClient
{
    /// <summary>
    /// List a verifiable credential templates.
    /// </summary>
    Task<Pager<VerifiableCredentialTemplateResponse>> ListAsync(
        ListVerifiableCredentialTemplatesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a verifiable credential template.
    /// </summary>
    WithRawResponseTask<CreateVerifiableCredentialTemplateResponseContent> CreateAsync(
        CreateVerifiableCredentialTemplateRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Get a verifiable credential template.
    /// </summary>
    WithRawResponseTask<GetVerifiableCredentialTemplateResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a verifiable credential template.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a verifiable credential template.
    /// </summary>
    WithRawResponseTask<UpdateVerifiableCredentialTemplateResponseContent> UpdateAsync(
        string id,
        UpdateVerifiableCredentialTemplateRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
