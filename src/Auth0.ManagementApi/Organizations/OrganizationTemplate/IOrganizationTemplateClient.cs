using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Organizations;

public partial interface IOrganizationTemplateClient
{
    /// <summary>
    /// Retrieve the organization template assigned to a specific organization. Returns the template object if one is explicitly assigned, or a 404 if no template is assigned.
    /// </summary>
    WithRawResponseTask<OrganizationTemplate> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Assign an Organization Template to an organization.
    /// </summary>
    WithRawResponseTask AssignOrganizationTemplateAsync(
        string id,
        string templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove an Organization Template assignment from an organization.
    /// </summary>
    WithRawResponseTask UnassignOrganizationTemplateAsync(
        string id,
        string templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
