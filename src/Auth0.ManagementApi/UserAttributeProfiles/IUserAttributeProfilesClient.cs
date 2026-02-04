using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IUserAttributeProfilesClient
{
    /// <summary>
    /// Retrieve a list of User Attribute Profiles. This endpoint supports Checkpoint pagination.
    /// </summary>
    Task<Pager<UserAttributeProfile>> ListAsync(
        ListUserAttributeProfileRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details about a single User Attribute Profile specified by ID.
    /// </summary>
    WithRawResponseTask<CreateUserAttributeProfileResponseContent> CreateAsync(
        CreateUserAttributeProfileRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a list of User Attribute Profile Templates.
    /// </summary>
    WithRawResponseTask<ListUserAttributeProfileTemplateResponseContent> ListTemplatesAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a User Attribute Profile Template.
    /// </summary>
    WithRawResponseTask<GetUserAttributeProfileTemplateResponseContent> GetTemplateAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details about a single User Attribute Profile specified by ID.
    /// </summary>
    WithRawResponseTask<GetUserAttributeProfileResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a single User Attribute Profile specified by ID.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the details of a specific User attribute profile, such as name, user_id and user_attributes.
    /// </summary>
    WithRawResponseTask<UpdateUserAttributeProfileResponseContent> UpdateAsync(
        string id,
        UpdateUserAttributeProfileRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
