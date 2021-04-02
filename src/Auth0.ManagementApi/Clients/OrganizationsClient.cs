using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    public class OrganizationsClient : BaseClient
    {
        readonly JsonConverter[] converters = new JsonConverter[] { new PagedListConverter<Organization>("organizations") };
        readonly JsonConverter[] connectionsConverters = new JsonConverter[] { new PagedListConverter<OrganizationConnection>("enabled_connections") };
        readonly JsonConverter[] membersConverters = new JsonConverter[] { new PagedListConverter<OrganizationMember>("members") };
        readonly JsonConverter[] invitationsConverters = new JsonConverter[] { new PagedListConverter<OrganizationInvitation>("invitations") };

        /// <summary>
        /// Initializes a new instance of <see cref="ClientsClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public OrganizationsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Retrieves a list of all organizations.
        /// </summary>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{Organization}"/> containing the organizations.</returns>
        public Task<IPagedList<Organization>> GetAllAsync(PaginationInfo pagination)
        {
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            var queryStrings = new Dictionary<string, string>
            {
                {"page", pagination.PageNo.ToString()},
                {"per_page", pagination.PerPage.ToString()},
                {"include_totals", pagination.IncludeTotals.ToString().ToLower()},
            };

            return Connection.GetAsync<IPagedList<Organization>>(BuildUri("organizations", queryStrings), DefaultHeaders, converters);
        }

        /// <summary>
        /// Retrieves an organization by its id.
        /// </summary>
        /// <param name="id">The id of the organization to retrieve.</param>
        /// <returns>The <see cref="Organization"/> retrieved.</returns>
        public Task<Organization> GetAsync(string id)
        {
            return Connection.GetAsync<Organization>(BuildUri($"organizations/{EncodePath(id)}"), DefaultHeaders);
        }

        /// <summary>
        /// Retrieves an organization by its name.
        /// </summary>
        /// <param name="name">The name of the organization to retrieve.</param>
        /// <returns>The <see cref="Organization"/> retrieved.</returns>
        public Task<Organization> GetByNameAsync(string name)
        {
            return Connection.GetAsync<Organization>(BuildUri($"organizations/name/{EncodePath(name)}"), DefaultHeaders);
        }

        /// <summary>
        /// Creates a new organization.
        /// </summary>
        /// <param name="request">The <see cref="OrganizationCreateRequest"/> containing the properties of the new organization.</param>
        /// <returns>The new <see cref="Organization"/> that has been created.</returns>
        public Task<Organization> CreateAsync(OrganizationCreateRequest request)
        {
            return Connection.SendAsync<Organization>(HttpMethod.Post, BuildUri("organizations"), request, DefaultHeaders);
        }

        /// <summary>
        /// Updates an organization.
        /// </summary>
        /// <param name="id">The id of the organization you want to update.</param>
        /// <param name="request">The <see cref="OrganizationUpdateRequest"/> containing the properties of the organization you want to update.</param>
        /// <returns>The <see cref="Organization"/> that was updated.</returns>
        public Task<Organization> UpdateAsync(string id, OrganizationUpdateRequest request)
        {
            return Connection.SendAsync<Organization>(new HttpMethod("PATCH"), BuildUri($"organizations/{EncodePath(id)}"), request, DefaultHeaders);
        }

        /// <summary>
        /// Deletes an organization.
        /// </summary>
        /// <param name="id">The id of the organization to delete.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"organizations/{EncodePath(id)}"), null, DefaultHeaders);
        }

        /// <summary>
        /// Retrieves a list of all organization connections.
        /// </summary>
        /// <param name="organizationId">The ID of the organization for which you want to retrieve the connections.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{OrganizationConnection}"/> containing the organization connections.</returns>
        public Task<IPagedList<OrganizationConnection>> GetAllConnectionsAsync(string organizationId, PaginationInfo pagination)
        {
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            var queryStrings = new Dictionary<string, string>
            {
                {"page", pagination.PageNo.ToString()},
                {"per_page", pagination.PerPage.ToString()},
                {"include_totals", pagination.IncludeTotals.ToString().ToLower()},
            };

            return Connection.GetAsync<IPagedList<OrganizationConnection>>(BuildUri($"organizations/{EncodePath(organizationId)}/enabled_connections", queryStrings), DefaultHeaders, connectionsConverters);
        }

        /// <summary>
        /// Retrieves an organization connection by its id.
        /// </summary>
        /// <param name="organizationId">The id of the organization for which you want to retrieve the connection.</param>
        /// <param name="connectionId">The id of the connection to retrieve.</param>
        /// <returns>The <see cref="OrganizationConnection"/> retrieved.</returns>
        public Task<OrganizationConnection> GetConnectionAsync(string organizationId, string connectionId)
        {
            return Connection.GetAsync<OrganizationConnection>(BuildUri($"organizations/{EncodePath(organizationId)}/enabled_connections/{EncodePath(connectionId)}"), DefaultHeaders);
        }

        /// <summary>
        /// Creates a new organization connection.
        /// </summary>
        /// <param name="organizationId">The id of the organization for which you want to add the connection.</param>
        /// <param name="request">The <see cref="OrganizationConnectionCreateRequest"/> containing the properties of the new organization connection.</param>
        /// <returns>The new <see cref="OrganizationConnection"/> that has been created.</returns>
        public Task<OrganizationConnection> CreateConnectionAsync(string organizationId, OrganizationConnectionCreateRequest request)
        {
            return Connection.SendAsync<OrganizationConnection>(HttpMethod.Post, BuildUri($"organizations/{EncodePath(organizationId)}/enabled_connections"), request, DefaultHeaders);
        }

        /// <summary>
        /// Updates an organization connection.
        /// </summary>
        /// <param name="organizationId">The id of the organization for which you want to update the connection.</param>
        /// <param name="connectionId">The id of the connection you want to update for the organization.</param>
        /// <param name="request">The <see cref="OrganizationConnectionUpdateRequest"/> containing the properties of the organization connection you want to update.</param>
        /// <returns>The <see cref="OrganizationConnection"/> that was updated.</returns>
        public Task<OrganizationConnection> UpdateConnectionAsync(string organizationId, string connectionId, OrganizationConnectionUpdateRequest request)
        {
            return Connection.SendAsync<OrganizationConnection>(new HttpMethod("PATCH"), BuildUri($"organizations/{EncodePath(organizationId)}/enabled_connections/{EncodePath(connectionId)}"), request, DefaultHeaders);
        }

        /// <summary>
        /// Deletes an organization connection.
        /// </summary>
        /// <param name="organizationId">The id of the organization for which you want to delete the connection.</param>
        /// <param name="connectionId">The id of the connection to delete from the organization.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteConnectionAsync(string organizationId, string connectionId)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"organizations/{EncodePath(organizationId)}/enabled_connections/{EncodePath(connectionId)}"), null, DefaultHeaders);
        }

        /// <summary>
        /// Add members to an organization.
        /// </summary>
        /// <param name="organizationId">The id of the organization for which you want to add members.</param>
        /// <param name="request">The <see cref="OrganizationAddMembersRequest"/> containing the members.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        public Task AddMembersAsync(string organizationId, OrganizationAddMembersRequest request)
        {
            return Connection.SendAsync<object>(HttpMethod.Post, BuildUri($"organizations/{EncodePath(organizationId)}/members"), request, DefaultHeaders);
        }

        /// <summary>
        /// Retrieves a list of all organization members.
        /// </summary>
        /// <param name="organizationId">The ID of the organization for which you want to retrieve the members.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{OrganizationMember}"/> containing the organization members.</returns>
        public Task<IPagedList<OrganizationMember>> GetAllMembersAsync(string organizationId, PaginationInfo pagination)
        {
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            var queryStrings = new Dictionary<string, string>
            {
                {"page", pagination.PageNo.ToString()},
                {"per_page", pagination.PerPage.ToString()},
                {"include_totals", pagination.IncludeTotals.ToString().ToLower()},
            };

            return Connection.GetAsync<IPagedList<OrganizationMember>>(BuildUri($"organizations/{EncodePath(organizationId)}/members", queryStrings), DefaultHeaders, membersConverters);
        }

        /// <summary>
        /// Deletes members from an organization.
        /// </summary>
        /// <param name="organizationId">The id of the organization for which you want to delete the members.</param>
        /// <param name="request">The <see cref="OrganizationDeleteMembersRequest"/> containing the members.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteMemberAsync(string organizationId, OrganizationDeleteMembersRequest request)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"organizations/{EncodePath(organizationId)}/members"), request, DefaultHeaders);
        }

        /// <summary>
        /// Add members to an organization.
        /// </summary>
        /// <param name="organizationId">The id of the organization for which you want to add roles to the given user.</param>
        /// <param name="userId">The id of the user for which you want to add roles.</param>
        /// <param name="request">The <see cref="OrganizationAddMemberRolesRequest"/> containing the roles.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
        public Task AddMemberRolesAsync(string organizationId, string userId, OrganizationAddMemberRolesRequest request)
        {
            return Connection.SendAsync<object>(HttpMethod.Post, BuildUri($"organizations/{EncodePath(organizationId)}/members/{EncodePath(userId)}/roles"), request, DefaultHeaders);
        }

        /// <summary>
        /// Retrieves a list of all roles for an organization members.
        /// </summary>
        /// <param name="organizationId">The id of the organization for which you want to retrieve the roles for a given user.</param>
        /// <param name="userId">The id of the user for which you want to retrieve the roles.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{OrganizationMember}"/> containing the organization members.</returns>
        public Task<IPagedList<OrganizationMember>> GetAllMemberRolesAsync(string organizationId, string userId, PaginationInfo pagination)
        {
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            var queryStrings = new Dictionary<string, string>
            {
                {"page", pagination.PageNo.ToString()},
                {"per_page", pagination.PerPage.ToString()},
                {"include_totals", pagination.IncludeTotals.ToString().ToLower()},
            };

            return Connection.GetAsync<IPagedList<OrganizationMember>>(BuildUri($"organizations/{EncodePath(organizationId)}/members/{EncodePath(userId)}/roles", queryStrings), DefaultHeaders, membersConverters);
        }

        /// <summary>
        /// Deletes roles from an organization member.
        /// </summary>
        /// <param name="organizationId">The id of the organization for which you want to delete roles for a given user.</param>
        /// <param name="userId">The id of the user for which you want to remove roles.</param>
        /// <param name="request">The <see cref="OrganizationDeleteMemberRolesRequest"/> containing the roles.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteMemberRolesAsync(string organizationId, string userId, OrganizationDeleteMemberRolesRequest request)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"organizations/{EncodePath(organizationId)}/members/{EncodePath(userId)}/roles"), request, DefaultHeaders);
        }

        /// <summary>
        /// Creates a new organization invitation.
        /// </summary>
        /// <param name="organizationId">The id of the organization to which you want to invite a user.</param>
        /// <param name="request">The <see cref="OrganizationCreateInvitationRequest"/> containing the properties of the new organization invitation.</param>
        /// <returns>The new <see cref="OrganizationInvitation"/> that has been created.</returns>
        public Task<OrganizationInvitation> CreateInvitationAsync(string organizationId, OrganizationCreateInvitationRequest request)
        {
            return Connection.SendAsync<OrganizationInvitation>(HttpMethod.Post, BuildUri($"organizations/{EncodePath(organizationId)}/invitations"), request, DefaultHeaders);
        }

        /// <summary>
        /// Retrieves a list of all organization invitations.
        /// </summary>
        /// <param name="organizationId">The id of the organization for which you want to retrieve the invitations.</param>
        /// <param name="request">The <see cref="OrganizationGetAllInvitationsRequest"/> containing the properties to retrieve the organization invitations.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{OrganizationInvitation}"/> containing the organization members.</returns>
        public Task<IPagedList<OrganizationInvitation>> GetAllInvitationsAsync(string organizationId, OrganizationGetAllInvitationsRequest request, PaginationInfo pagination)
        {
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            var queryStrings = new Dictionary<string, string>
            {
                {"page", pagination.PageNo.ToString()},
                {"per_page", pagination.PerPage.ToString()},
                {"include_totals", pagination.IncludeTotals.ToString().ToLower()},
                {"fields", request.Fields},
                {"include_fields", request.IncludeFields?.ToString().ToLower()},
                {"sort", request.Sort},
            };

            return Connection.GetAsync<IPagedList<OrganizationInvitation>>(BuildUri($"organizations/{EncodePath(organizationId)}/invitations", queryStrings), DefaultHeaders, invitationsConverters);
        }

        /// <summary>
        /// Retrieves an organization invitation by its id.
        /// </summary>
        /// <param name="organizationId">The id of the organization for which you want to retrieve the invitation.</param>
        /// <param name="invitationId">The id of the organization invitation to retrieve.</param>
        /// <param name="request">The <see cref="OrganizationGetInvitationRequest"/> containing the properties to retrieve the organization invitation.</param>
        /// <returns>The <see cref="OrganizationInvitation"/> retrieved.</returns>
        public Task<OrganizationInvitation> GetInvitationAsync(string organizationId, string invitationId, OrganizationGetInvitationRequest request)
        {
            var queryStrings = new Dictionary<string, string>
            {
                {"fields", request.Fields},
                {"include_fields", request.IncludeFields?.ToString().ToLower()}
            };

            return Connection.GetAsync<OrganizationInvitation>(BuildUri($"organizations/{EncodePath(organizationId)}/invitations/{EncodePath(invitationId)}", queryStrings), DefaultHeaders);
        }

        /// <summary>
        /// Deletes an organization invitation.
        /// </summary>
        /// <param name="organizationId">The id of the organization for which you want to delete the invitation.</param>
        /// <param name="invitationId">The id of the invitation you want to remove.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteInvitationAsync(string organizationId, string invitationId)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"organizations/{EncodePath(organizationId)}/invitations/{EncodePath(invitationId)}"), null, DefaultHeaders);
        }

    }
}
