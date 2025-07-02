using System.Threading;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models.SelfServiceProfiles;
using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.Clients;

public interface ISelfServiceProfilesClient
{
    /// <summary>
    /// Retrieve self-service-profile information.
    /// </summary>
    /// <param name="pagination"><see cref="PaginationInfo"/></param>
    /// <param name="cancellationToken"> <see cref="CancellationToken"/></param>
    /// <returns><see cref="IPagedList{T}"/> of <see cref="SelfServiceProfile"/></returns>
    Task<IPagedList<SelfServiceProfile>> GetAllAsync(PaginationInfo pagination = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Create self-service-profile.
    /// </summary>
    /// <param name="request"><see cref="SelfServiceProfileCreateRequest"/></param>
    /// <param name="cancellationToken"> <see cref="CancellationToken"/></param>
    /// <returns><see cref="SelfServiceProfile"/></returns>
    Task<SelfServiceProfile> CreateAsync(SelfServiceProfileCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve self-service-profile by id.
    /// </summary>
    /// <param name="id">Self-Service-Profile ID</param>
    /// <param name="cancellationToken"> <see cref="CancellationToken"/></param>
    /// <returns><see cref="SelfServiceProfile"/></returns>
    Task<SelfServiceProfile> GetAsync(string id, CancellationToken cancellationToken = default);
        
    /// <summary>
    /// Delete a self-service-profile by id.
    /// </summary>
    /// <param name="id">Self-Service-Profile ID</param>
    /// <param name="cancellationToken"> <see cref="CancellationToken"/></param>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve self-service-profile by id.
    /// </summary>
    /// <param name="id">Self-Service-Profile ID</param>
    /// <param name="request"><see cref="SelfServiceProfileUpdateRequest"/></param>
    /// <param name="cancellationToken"> <see cref="CancellationToken"/></param>
    /// <returns><see cref="SelfServiceProfile"/></returns>
    Task<SelfServiceProfile> UpdateAsync(string id, SelfServiceProfileUpdateRequest request,  CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates an sso-access ticket to initiate the Self Service SSO Flow using a self-service profile
    /// </summary>
    /// <param name="id">The id of the sso-profile to retrieve</param>
    /// <param name="request"><see cref="SelfServiceSsoTicketCreateRequest"/></param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <returns><see cref="SelfServiceSsoTicket"/></returns>
    Task<SelfServiceSsoTicket> CreateSsoTicketAsync(string id, SelfServiceSsoTicketCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Revokes an SSO access ticket and invalidates associated sessions.
    /// The ticket will no longer be accepted to initiate a Self-Service SSO session.
    /// If any users have already started a session through this ticket, their session will be terminated.
    /// Clients should expect a 202 Accepted response upon successful processing, indicating that the request
    /// has been acknowledged and that the revocation is underway but may not be fully completed at the time of response.
    /// If the specified ticket does not exist, a 202 Accepted response is also returned,
    /// signaling that no further action is required.
    /// Clients should treat these 202 responses as an acknowledgment that the request has been accepted and
    /// is in progress, even if the ticket was not found.
    /// </summary>
    /// <param name="ticketId">The id of the ticket to revoke</param>
    /// <param name="profileId">The id of the self-service profile</param>
    /// <param name="cancellationToken"> <see cref="CancellationToken"/> </param>
    /// <returns><see cref="SelfServiceSsoTicket"/></returns>
    Task RevokeSsoTicketAsync(string profileId, string ticketId, CancellationToken cancellationToken = default);
        
    /// <summary>
    /// Retrieves text customizations for a given self-service profile, language and Self Service SSO Flow page
    /// </summary>
    /// <param name="id">The id of the self-service profile.</param>
    /// <param name="language">The language of the custom text.</param>
    /// <param name="page">The page where the custom text is shown.</param>
    /// <param name="cancellationToken"> <see cref="CancellationToken"/> </param>
    /// <returns>The list of custom text keys and values.</returns>
    Task<object> GetCustomTextForSelfServiceProfileAsync(string id, string language, string page, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates text customizations for a given self-service profile, language and Self Service SSO Flow page.
    /// </summary>
    /// <param name="id">The id of the self-service profile.</param>
    /// <param name="language">The language of the custom text.</param>
    /// <param name="page">The page where the custom text is shown.</param>
    /// <param name="body">The list of text keys and values to customize the self-service SSO page.
    /// Values can be plain text or rich HTML content limited to basic styling tags and hyperlinks.</param>
    /// <param name="cancellationToken"> <see cref="CancellationToken"/> </param>
    /// <returns>The resulting list of custom text keys and values.</returns>
    Task<object> SetCustomTextForSelfServiceProfileAsync(string id, string language, string page, object body, CancellationToken cancellationToken = default);
}