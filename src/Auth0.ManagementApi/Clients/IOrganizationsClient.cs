namespace Auth0.ManagementApi.Clients
{
  using System.Threading;
  using System.Threading.Tasks;
  using Models;
  using Paging;

  public interface IOrganizationsClient
  {
    /// <summary>
    /// Retrieves a list of all organizations.
    /// </summary>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{Organization}"/> containing the organizations.</returns>
    Task<IPagedList<Organization>> GetAllAsync(PaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of all organizations using checkpoint <paramref name="pagination"/>.
    /// </summary>
    /// <param name="pagination">Specifies <see cref="CheckpointPaginationInfo"/> to use in requesting checkpoint-paginated results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="ICheckpointPagedList{Organization}"/> containing the organizations.</returns>
    Task<ICheckpointPagedList<Organization>> GetAllAsync(CheckpointPaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an organization by its id.
    /// </summary>
    /// <param name="id">The id of the organization to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="Organization"/> retrieved.</returns>
    Task<Organization> GetAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an organization by its name.
    /// </summary>
    /// <param name="name">The name of the organization to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="Organization"/> retrieved.</returns>
    Task<Organization> GetByNameAsync(string name, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new organization.
    /// </summary>
    /// <param name="request">The <see cref="OrganizationCreateRequest"/> containing the properties of the new organization.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The new <see cref="Organization"/> that has been created.</returns>
    Task<Organization> CreateAsync(OrganizationCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an organization.
    /// </summary>
    /// <param name="id">The id of the organization you want to update.</param>
    /// <param name="request">The <see cref="OrganizationUpdateRequest"/> containing the properties of the organization you want to update.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="Organization"/> that was updated.</returns>
    Task<Organization> UpdateAsync(string id, OrganizationUpdateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an organization.
    /// </summary>
    /// <param name="id">The id of the organization to delete.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of all organization connections.
    /// </summary>
    /// <param name="organizationId">The ID of the organization for which you want to retrieve the connections.</param>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{OrganizationConnection}"/> containing the organization connections.</returns>
    Task<IPagedList<OrganizationConnection>> GetAllConnectionsAsync(string organizationId, PaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an organization connection by its id.
    /// </summary>
    /// <param name="organizationId">The id of the organization for which you want to retrieve the connection.</param>
    /// <param name="connectionId">The id of the connection to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="OrganizationConnection"/> retrieved.</returns>
    Task<OrganizationConnection> GetConnectionAsync(string organizationId, string connectionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new organization connection.
    /// </summary>
    /// <param name="organizationId">The id of the organization for which you want to add the connection.</param>
    /// <param name="request">The <see cref="OrganizationConnectionCreateRequest"/> containing the properties of the new organization connection.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The new <see cref="OrganizationConnection"/> that has been created.</returns>
    Task<OrganizationConnection> CreateConnectionAsync(string organizationId, OrganizationConnectionCreateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an organization connection.
    /// </summary>
    /// <param name="organizationId">The id of the organization for which you want to update the connection.</param>
    /// <param name="connectionId">The id of the connection you want to update for the organization.</param>
    /// <param name="request">The <see cref="OrganizationConnectionUpdateRequest"/> containing the properties of the organization connection you want to update.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="OrganizationConnection"/> that was updated.</returns>
    Task<OrganizationConnection> UpdateConnectionAsync(string organizationId, string connectionId, OrganizationConnectionUpdateRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an organization connection.
    /// </summary>
    /// <param name="organizationId">The id of the organization for which you want to delete the connection.</param>
    /// <param name="connectionId">The id of the connection to delete from the organization.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteConnectionAsync(string organizationId, string connectionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add members to an organization.
    /// </summary>
    /// <param name="organizationId">The id of the organization for which you want to add members.</param>
    /// <param name="request">The <see cref="OrganizationAddMembersRequest"/> containing the members.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task AddMembersAsync(string organizationId, OrganizationAddMembersRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of all organization members.
    /// </summary>
    /// <param name="organizationId">The ID of the organization for which you want to retrieve the members.</param>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{OrganizationMember}"/> containing the organization members.</returns>
    Task<IPagedList<OrganizationMember>> GetAllMembersAsync(string organizationId, PaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of all organization members.
    /// </summary>
    /// <param name="organizationId">The ID of the organization for which you want to retrieve the members.</param>
    /// <param name="request">Specifies criteria to use when querying organization members.</param>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{OrganizationMember}"/> containing the organization members.</returns>
    Task<IPagedList<OrganizationMember>> GetAllMembersAsync(string organizationId, OrganizationGetAllMembersRequest request, PaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of all organization members using checkpoint <paramref name="pagination"/>.
    /// </summary>
    /// <param name="organizationId">The ID of the organization for which you want to retrieve the members.</param>
    /// <param name="pagination">Specifies <see cref="CheckpointPaginationInfo"/> to use in requesting checkpoint-paginated results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="ICheckpointPagedList{OrganizationMember}"/> containing the organization members.</returns>
    Task<ICheckpointPagedList<OrganizationMember>> GetAllMembersAsync(string organizationId, CheckpointPaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of all organization members using checkpoint <paramref name="pagination"/>.
    /// </summary>
    /// <param name="organizationId">The ID of the organization for which you want to retrieve the members.</param>
    /// <param name="request">Specifies criteria to use when querying organization members.</param>
    /// <param name="pagination">Specifies <see cref="CheckpointPaginationInfo"/> to use in requesting checkpoint-paginated results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="ICheckpointPagedList{OrganizationMember}"/> containing the organization members.</returns>
    Task<ICheckpointPagedList<OrganizationMember>> GetAllMembersAsync(string organizationId, OrganizationGetAllMembersRequest request, CheckpointPaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes members from an organization.
    /// </summary>
    /// <param name="organizationId">The id of the organization for which you want to delete the members.</param>
    /// <param name="request">The <see cref="OrganizationDeleteMembersRequest"/> containing the members.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteMemberAsync(string organizationId, OrganizationDeleteMembersRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add members to an organization.
    /// </summary>
    /// <param name="organizationId">The id of the organization for which you want to add roles to the given user.</param>
    /// <param name="userId">The id of the user for which you want to add roles.</param>
    /// <param name="request">The <see cref="OrganizationAddMemberRolesRequest"/> containing the roles.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
    Task AddMemberRolesAsync(string organizationId, string userId, OrganizationAddMemberRolesRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of all roles for an organization members.
    /// </summary>
    /// <param name="organizationId">The id of the organization for which you want to retrieve the roles for a given user.</param>
    /// <param name="userId">The id of the user for which you want to retrieve the roles.</param>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{OrganizationMember}"/> containing the organization members.</returns>
    Task<IPagedList<Role>> GetAllMemberRolesAsync(string organizationId, string userId, PaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes roles from an organization member.
    /// </summary>
    /// <param name="organizationId">The id of the organization for which you want to delete roles for a given user.</param>
    /// <param name="userId">The id of the user for which you want to remove roles.</param>
    /// <param name="request">The <see cref="OrganizationDeleteMemberRolesRequest"/> containing the roles.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteMemberRolesAsync(string organizationId, string userId, OrganizationDeleteMemberRolesRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new organization invitation.
    /// </summary>
    /// <param name="organizationId">The id of the organization to which you want to invite a user.</param>
    /// <param name="request">The <see cref="OrganizationCreateInvitationRequest"/> containing the properties of the new organization invitation.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The new <see cref="OrganizationInvitation"/> that has been created.</returns>
    Task<OrganizationInvitation> CreateInvitationAsync(string organizationId, OrganizationCreateInvitationRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of all organization invitations.
    /// </summary>
    /// <param name="organizationId">The id of the organization for which you want to retrieve the invitations.</param>
    /// <param name="request">The <see cref="OrganizationGetAllInvitationsRequest"/> containing the properties to retrieve the organization invitations.</param>
    /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="IPagedList{OrganizationInvitation}"/> containing the organization members.</returns>
    Task<IPagedList<OrganizationInvitation>> GetAllInvitationsAsync(string organizationId, OrganizationGetAllInvitationsRequest request, PaginationInfo pagination, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an organization invitation by its id.
    /// </summary>
    /// <param name="organizationId">The id of the organization for which you want to retrieve the invitation.</param>
    /// <param name="invitationId">The id of the organization invitation to retrieve.</param>
    /// <param name="request">The <see cref="OrganizationGetInvitationRequest"/> containing the properties to retrieve the organization invitation.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="OrganizationInvitation"/> retrieved.</returns>
    Task<OrganizationInvitation> GetInvitationAsync(string organizationId, string invitationId, OrganizationGetInvitationRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an organization invitation.
    /// </summary>
    /// <param name="organizationId">The id of the organization for which you want to delete the invitation.</param>
    /// <param name="invitationId">The id of the invitation you want to remove.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteInvitationAsync(string organizationId, string invitationId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get client grants associated with an organization.
    /// </summary>
    /// <param name="organizationId">The id of the organization for which you want to retrieve the client grants.</param>
    /// <param name="request">Specifies criteria to use when querying client grants for the organization.</param>
    /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="IPagedList{ClientGrant}"/> containing the client grants requested.</returns>
    Task<IPagedList<OrganizationClientGrant>> GetAllClientGrantsAsync(string organizationId,
      OrganizationGetClientGrantsRequest request, PaginationInfo pagination = null,
      CancellationToken cancellationToken = default);

    /// <summary>
    /// Associate a client grant with an organization
    /// </summary>
    /// <param name="organizationId">The id of the organization to which you want to associate the client grant.</param>
    /// <param name="request">The <see cref="OrganizationCreateClientGrantRequest"/> containing the properties of the Client Grant to associate with the organization.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The new <see cref="ClientGrant"/> that has been created.</returns>
    Task<OrganizationClientGrant> CreateClientGrantAsync(string organizationId,
      OrganizationCreateClientGrantRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove a client grant from an organization.
    /// </summary>
    /// <param name="organizationId">The id of the organization for which you want to delete the client grant.</param>
    /// <param name="clientGrantId">The id of the client grant you want to delete from the organization</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteClientGrantAsync(string organizationId, string clientGrantId,
      CancellationToken cancellationToken = default);
  }
}
