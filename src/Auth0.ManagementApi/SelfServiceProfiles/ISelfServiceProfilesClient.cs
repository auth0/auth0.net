using Auth0.ManagementApi.Core;
using Auth0.ManagementApi.SelfServiceProfiles;

namespace Auth0.ManagementApi;

public partial interface ISelfServiceProfilesClient
{
    public Auth0.ManagementApi.SelfServiceProfiles.ICustomTextClient CustomText { get; }
    public ISsoTicketClient SsoTicket { get; }

    /// <summary>
    /// Retrieves self-service profiles.
    /// </summary>
    Task<Pager<SelfServiceProfile>> ListAsync(
        ListSelfServiceProfilesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a self-service profile.
    /// </summary>
    WithRawResponseTask<CreateSelfServiceProfileResponseContent> CreateAsync(
        CreateSelfServiceProfileRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a self-service profile by Id.
    /// </summary>
    WithRawResponseTask<GetSelfServiceProfileResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes a self-service profile by Id.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates a self-service profile.
    /// </summary>
    WithRawResponseTask<UpdateSelfServiceProfileResponseContent> UpdateAsync(
        string id,
        UpdateSelfServiceProfileRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
