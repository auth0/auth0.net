using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /users endpoints.
    /// </summary>
    public class UsersClient : BaseClient
    {
        readonly JsonConverter[] usersConverters = new JsonConverter[] { new PagedListConverter<User>("users") };
        readonly JsonConverter[] logsConverters = new JsonConverter[] { new PagedListConverter<LogEntry>("logs", true) };
        readonly JsonConverter[] rolesConverters = new JsonConverter[] { new PagedListConverter<Role>("roles") };
        readonly JsonConverter[] permissionsConverters = new JsonConverter[] { new PagedListConverter<UserPermission>("permissions") };
        readonly JsonConverter[] organizationsConverters = new JsonConverter[] { new PagedListConverter<Organization>("organizations") };

        /// <summary>
        /// Initializes a new instance of <see cref="UsersClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public UsersClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Assigns Roles to a user.
        /// </summary>
        /// <param name="id">The ID of the user to assign roles to.</param>
        /// <param name="request">A <see cref="AssignRolesRequest" /> containing the role IDs to assign to the user.</param>
        /// <param name="token"></param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous assign operation.</returns>
        public Task AssignRolesAsync(string id, AssignRolesRequest request, CancellationToken token = default)
        {
            return Connection.SendAsync<AssignRolesRequest>(HttpMethod.Post, BuildUri($"users/{EncodePath(id)}/roles"), request, DefaultHeaders, token: token);
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="request">The <see cref="UserCreateRequest" /> containing the properties of the user to create.</param>
        /// <param name="token"></param>
        /// <returns>The newly created <see cref="User"/>.</returns>
        public Task<User> CreateAsync(UserCreateRequest request, CancellationToken token = default)
        {
            return Connection.SendAsync<User>(HttpMethod.Post, BuildUri("users"), request, DefaultHeaders, token: token);
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="id">The id of the user to delete.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"users/{EncodePath(id)}"), null, DefaultHeaders);
        }

        /// <summary>
        /// Deletes a user's multifactor provider.
        /// </summary>
        /// <param name="id">The id of the user who multi factor provider to delete.</param>
        /// <param name="provider">The type of the multifactor provider. Supported values 'duo' or 'google-authenticator'.</param>
        /// <param name="token"></param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteMultifactorProviderAsync(string id, string provider, CancellationToken token = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"users/{EncodePath(id)}/multifactor/{EncodePath(provider)}"), null, DefaultHeaders, token: token);
        }

        /// <summary>
        /// Lists or search for users based on criteria.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying users.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <param name="token"></param>
        /// <returns>An <see cref="IPagedList{GetUsersRequest}"/> containing the list of users.</returns>
        public Task<IPagedList<User>> GetAllAsync(GetUsersRequest request, PaginationInfo pagination, CancellationToken token = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            return Connection.GetAsync<IPagedList<User>>(BuildUri($"users",
                new Dictionary<string, string>
                {
                    {"sort", request.Sort},
                    {"connection", request.Connection},
                    {"fields", request.Fields},
                    {"include_fields", request.IncludeFields?.ToString().ToLower()},
                    {"q", request.Query},
                    {"search_engine", request.SearchEngine},
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()},
                }), DefaultHeaders, usersConverters, token);
        }

        /// <summary>
        /// Gets a user.
        /// </summary>
        /// <param name="id">The id of the user to retrieve.</param>
        /// <param name="fields">
        /// A comma separated list of fields to include or exclude (depending on includeFields) from the
        /// result, empty to retrieve all fields
        /// </param>
        /// <param name="includeFields">
        /// true if the fields specified are to be included in the result, false otherwise (defaults to
        /// true)
        /// </param>
        /// <param name="token"></param>
        /// <returns>The <see cref="User"/> that was requested.</returns>
        public Task<User> GetAsync(string id, string fields = null, bool includeFields = true, CancellationToken token = default)
        {
            return Connection.GetAsync<User>(BuildUri($"users/{EncodePath(id)}",
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                }), DefaultHeaders, token: token);
        }

        /// <summary>
        /// Retrieve every log event for a specific user.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying logs for a user.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <param name="token"></param>
        /// <returns>An <see cref="IPagedList{LogEntry}"/> containing the log entries for the user.</returns>
        public Task<IPagedList<LogEntry>> GetLogsAsync(GetUserLogsRequest request, PaginationInfo pagination, CancellationToken token = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            return Connection.GetAsync<IPagedList<LogEntry>>(BuildUri($"users/{EncodePath(request.UserId)}/logs",
                new Dictionary<string, string>
                {
                    {"sort", request.Sort},
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }), DefaultHeaders, logsConverters, token);
        }

        /// <summary>
        /// Retrieve assigned roles for a specific user.
        /// </summary>
        /// <param name="userId">The user id of the roles to retrieve.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <param name="token"></param>
        /// <returns>An <see cref="IPagedList{Role}"/> containing the roles for the user.</returns>
        public Task<IPagedList<Role>> GetRolesAsync(string userId, PaginationInfo pagination, CancellationToken token = default)
        {
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            return Connection.GetAsync<IPagedList<Role>>(BuildUri($"users/{EncodePath(userId)}/roles",
                new Dictionary<string, string>
                {
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }), DefaultHeaders, rolesConverters, token);
        }

        /// <summary>
        /// Gets all users by email address.
        /// </summary>
        /// <param name="email">The email address to search for.</param>
        /// <param name="fields"> A comma separated list of fields to include or exclude (depending on <paramref name="includeFields"/>) from the result, null to retrieve all fields.</param>
        /// <param name="includeFields">true if the fields specified are to be included in the result, false otherwise. Defaults to true.</param>
        /// <param name="token"></param>
        /// <returns>A <see cref="IList{User}"/> containing all users for this email address.</returns>
        public Task<IList<User>> GetUsersByEmailAsync(string email, string fields = null, bool? includeFields = null, CancellationToken token = default)
        {
            return Connection.GetAsync<IList<User>>(BuildUri($"users-by-email",
                new Dictionary<string, string>
                {
                    {"email", email},
                    {"fields", fields},
                    {"include_fields", includeFields?.ToString().ToLower()}
                }), DefaultHeaders, token: token);
        }

        /// <summary>
        /// Get a list of Guardian enrollments.
        /// </summary>
        /// <param name="id">The user_id of the user to retrieve.</param>
        /// <param name="token"></param>
        /// <returns>A Task representing the operation and potential return value.</returns>
        public Task<IList<EnrollmentsResponse>> GetEnrollmentsAsync(string id, CancellationToken token = default)
        {
            return Connection.GetAsync<IList<EnrollmentsResponse>>(BuildUri($"users/{EncodePath(id)}/enrollments"), DefaultHeaders, token: token);
        }

        /// <summary>
        /// Invalidate all remembered browsers for MFA.
        /// </summary>
        /// <param name="id">The user_id of the user which will have its remembered browsers for MFA invalidated.</param>
        /// <param name="token"></param>
        /// <returns>A Task representing the operation and potential return value.</returns>
        public Task InvalidateRememberBrowserAsync(string id, CancellationToken token = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Post, BuildUri($"users/{EncodePath(id)}/multifactor/actions/invalidate-remember-browser"), null, DefaultHeaders, token: token);
        }

        /// <summary>
        /// Generate new Guardian recovery code.
        /// </summary>
        /// <param name="id">The user_id of the user which guardian code will be regenerated.</param>
        /// <param name="token"></param>
        /// <returns>A Task representing the operation and potential return value.</returns>
        public Task<GenerateRecoveryCodeResponse> GenerateRecoveryCodeAsync(string id, CancellationToken token = default)
        {
            return Connection.SendAsync<GenerateRecoveryCodeResponse>(HttpMethod.Post, BuildUri($"users/{EncodePath(id)}/recovery-code-regeneration"), null, DefaultHeaders, token: token);
        }

        /// <summary>
        /// Links a secondary account to a primary account.
        /// </summary>
        /// <param name="id">The ID of the primary account.</param>
        /// <param name="request">The <see cref="UserAccountLinkRequest" /> containing details of the secondary account to link.</param>
        /// <param name="token"></param>
        /// <returns>A <see cref="IList{AccountLinkResponse}"/> containing details about this account link.</returns>
        public Task<IList<AccountLinkResponse>> LinkAccountAsync(string id, UserAccountLinkRequest request, CancellationToken token = default)
        {
            return Connection.SendAsync<IList<AccountLinkResponse>>(HttpMethod.Post, BuildUri($"users/{EncodePath(id)}/identities"), request, DefaultHeaders, token: token);
        }

        /// <summary>
        /// Links a secondary account to a primary account.
        /// </summary>
        /// <param name="id">The ID of the primary account.</param>
        /// <param name="primaryJwtToken">The JWT of the primary account.</param>
        /// <param name="secondaryJwtToken">The JWT for the secondary account you wish to link.</param>
        /// <param name="token"></param>
        /// <returns>A <see cref="IList{AccountLinkResponse}"/> containing details about this account link.</returns>
        public Task<IList<AccountLinkResponse>> LinkAccountAsync(string id, string primaryJwtToken, string secondaryJwtToken, CancellationToken token = default)
        {
            var request = new UserAccountJwtLinkRequest
            {
                LinkWith = secondaryJwtToken
            };

            return Connection.SendAsync<IList<AccountLinkResponse>>(HttpMethod.Post,
                BuildUri($"users/{EncodePath(id)}/identities"), request,
                new Dictionary<string, string>(DefaultHeaders)
                {
                    ["Authorization"] = $"Bearer {primaryJwtToken}"
                }, token: token);
        }

        /// <summary>
        /// Removes Roles from a user.
        /// </summary>
        /// <param name="id">The ID of the user to remove roles from.</param>
        /// <param name="request">A <see cref="AssignRolesRequest" /> containing the role IDs to remove to the user.</param>
        /// <param name="token"></param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous remove operation.</returns>
        public Task RemoveRolesAsync(string id, AssignRolesRequest request, CancellationToken token = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"users/{EncodePath(id)}/roles"), request, DefaultHeaders, token: token);
        }

        /// <summary>
        /// Unlinks user accounts
        /// </summary>
        /// <param name="primaryUserId">The ID of the primary account.</param>
        /// <param name="provider">The type of the identity provider.</param>
        /// <param name="secondaryUserId">The ID for the secondary account.</param>
        /// <param name="token"></param>
        /// <returns>A <see cref="IList{AccountLinkResponse}"/> containing details about this account link.</returns>
        public Task<IList<AccountLinkResponse>> UnlinkAccountAsync(string primaryUserId, string provider, string secondaryUserId, CancellationToken token = default)
        {
            return Connection.SendAsync<IList<AccountLinkResponse>>(HttpMethod.Delete,
                BuildUri($"users/{EncodePath(primaryUserId)}/identities/{EncodePath(provider)}/{EncodePath(secondaryUserId)}"), null, DefaultHeaders, token: token);
        }

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="id">The id of the user to update.</param>
        /// <param name="request">The <see cref="UserUpdateRequest" /> containing the information you wish to update.</param>
        /// <param name="token"></param>
        /// <returns>The newly updated <see cref="User"/>.</returns>
        public Task<User> UpdateAsync(string id, UserUpdateRequest request, CancellationToken token = default)
        {
            return Connection.SendAsync<User>(new HttpMethod("PATCH"), BuildUri($"users/{EncodePath(id)}"), request, DefaultHeaders, token: token);
        }

        /// <summary>
        /// Get the permissions assigned to the user.
        /// </summary>
        /// <param name="id">The id of the user to obtain the permissions for.</param>
        /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
        /// <param name="token"></param>
        /// <returns>An <see cref="IPagedList{Permission}"/> containing the assigned permissions for this user.</returns>
        public Task<IPagedList<UserPermission>> GetPermissionsAsync(string id, PaginationInfo pagination, CancellationToken token = default)
        {
            return Connection.GetAsync<IPagedList<UserPermission>>(BuildUri($"users/{EncodePath(id)}/permissions",
                new Dictionary<string, string>
                {
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }), DefaultHeaders, permissionsConverters, token);
        }

        /// <summary>
        /// Assign permissions to a user.
        /// </summary>
        /// <param name="id">The ID of the user to assign permissions to.</param>
        /// <param name="request">A <see cref="AssignPermissionsRequest" /> containing the permission identifiers to assign to the user.</param>
        /// <param name="token"></param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous assignment operation.</returns>
        public Task AssignPermissionsAsync(string id, AssignPermissionsRequest request, CancellationToken token = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Post, BuildUri($"users/{EncodePath(id)}/permissions"), request, DefaultHeaders, token: token);
        }

        /// <summary>
        /// Removes permissions assigned to a user.
        /// </summary>
        /// <param name="id">The ID of the user to remove permissions from.</param>
        /// <param name="request">A <see cref="AssignPermissionsRequest" /> containing the permission identifiers to remove from the user.</param>
        /// <param name="token"></param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous remove operation.</returns>
        public Task RemovePermissionsAsync(string id, AssignPermissionsRequest request, CancellationToken token = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"users/{EncodePath(id)}/permissions"), request, DefaultHeaders, token: token);
        }

        /// <summary>
        /// Lists organizations for a user.
        /// </summary>
        /// <param name="userId">The ID of the user for which you want to retrieve the organizations.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <param name="token"></param>
        /// <returns>An <see cref="IPagedList{Organization}"/> containing the list of organizations.</returns>
        public Task<IPagedList<Organization>> GetAllOrganizationsAsync(string userId, PaginationInfo pagination, CancellationToken token = default)
        {
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            return Connection.GetAsync<IPagedList<Organization>>(BuildUri($"users/{EncodePath(userId)}/organizations",
                new Dictionary<string, string>
                {
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()},
                }), DefaultHeaders, organizationsConverters, token);
        }
    }
}
