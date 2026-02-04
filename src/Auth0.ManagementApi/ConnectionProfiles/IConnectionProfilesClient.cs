using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IConnectionProfilesClient
{
    /// <summary>
    /// Retrieve a list of Connection Profiles. This endpoint supports Checkpoint pagination.
    /// </summary>
    Task<Pager<ConnectionProfile>> ListAsync(
        ListConnectionProfileRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a Connection Profile.
    /// </summary>
    WithRawResponseTask<CreateConnectionProfileResponseContent> CreateAsync(
        CreateConnectionProfileRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of Connection Profile Templates.
    /// </summary>
    WithRawResponseTask<ListConnectionProfileTemplateResponseContent> ListTemplatesAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a Connection Profile Template.
    /// </summary>
    WithRawResponseTask<GetConnectionProfileTemplateResponseContent> GetTemplateAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details about a single Connection Profile specified by ID.
    /// </summary>
    WithRawResponseTask<GetConnectionProfileResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a single Connection Profile specified by ID.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the details of a specific Connection Profile.
    /// </summary>
    WithRawResponseTask<UpdateConnectionProfileResponseContent> UpdateAsync(
        string id,
        UpdateConnectionProfileRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
