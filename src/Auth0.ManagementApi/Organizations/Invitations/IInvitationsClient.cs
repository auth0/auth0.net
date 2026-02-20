using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations;

public partial interface IInvitationsClient
{
    /// <summary>
    /// Retrieve a detailed list of invitations sent to users for a specific Organization. The list includes details such as inviter and invitee information, invitation URLs, and dates of creation and expiration. To learn more about Organization invitations, review <see href="https://auth0.com/docs/manage-users/organizations/configure-organizations/invite-members">Invite Organization Members</see>.
    /// </summary>
    Task<Pager<OrganizationInvitation>> ListAsync(
        string id,
        ListOrganizationInvitationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a user invitation for a specific Organization. Upon creation, the listed user receives an email inviting them to join the Organization. To learn more about Organization invitations, review <see href="https://auth0.com/docs/manage-users/organizations/configure-organizations/invite-members">Invite Organization Members</see>.
    /// </summary>
    WithRawResponseTask<CreateOrganizationInvitationResponseContent> CreateAsync(
        string id,
        CreateOrganizationInvitationRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetOrganizationInvitationResponseContent> GetAsync(
        string id,
        string invitationId,
        GetOrganizationInvitationRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string id,
        string invitationId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
