using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IOrganizationTemplatesClient
{
    /// <summary>
    /// Retrieve a list of Organization Templates. This endpoint supports Checkpoint pagination. Results are returned in a stable order, sorted by their identifier (`id`) in ascending order.
    /// </summary>
    Task<Pager<OrganizationTemplate>> ListAsync(
        ListOrganizationTemplatesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create an Organization Template.
    /// </summary>
    WithRawResponseTask<OrganizationTemplate> CreateAsync(
        CreateOrganizationTemplateRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details about a single Organization Template specified by ID.
    /// </summary>
    WithRawResponseTask<OrganizationTemplate> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the details of a specific Organization Template.
    /// </summary>
    WithRawResponseTask<OrganizationTemplate> UpdateAsync(
        string id,
        UpdateOrganizationTemplateRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of organizations assigned to an Organization Template. This endpoint supports Checkpoint pagination. Results are returned in a stable order, sorted by their identifier (`id`) in ascending order.
    /// </summary>
    Task<Pager<OrganizationTemplateAssignedOrganization>> ListOrganizationsAsync(
        string id,
        ListTemplateOrganizationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
