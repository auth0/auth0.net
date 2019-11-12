using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /users endpoints.
    /// </summary>
    public class UsersClient : ClientBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="UsersClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public UsersClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Assigns Roles to a user.
        /// </summary>
        /// <param name="id">The ID of the user to assign roles to.</param>
        /// <param name="request">A <see cref="AssignRolesRequest" /> containing the role IDs to assign to the user.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous assign operation.</returns>
        public Task AssignRolesAsync(string id, AssignRolesRequest request)
        {
            return Connection.RunAsync<AssignRolesRequest>(HttpMethod.Post, $"users/{id}/roles", request);
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="request">The <see cref="UserCreateRequest" /> containing the properties of the user to create.</param>
        /// <returns>The newly created <see cref="User"/>.</returns>
        public Task<User> CreateAsync(UserCreateRequest request)
        {
            return Connection.RunAsync<User>(HttpMethod.Post, "users", request);
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

            return Connection.DeleteAsync<object>($"users/{id}");
        }

        /// <summary>
        /// Deletes a user's multifactor provider.
        /// </summary>
        /// <param name="id">The id of the user who multi factor provider to delete.</param>
        /// <param name="provider">The type of the multifactor provider. Supported values 'duo' or 'google-authenticator'.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteMultifactorProviderAsync(string id, string provider)
        {
            return Connection.DeleteAsync<object>($"users/{id}/multifactor/{provider}");
        }

        /// <summary>
        /// Lists or search for users based on criteria.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying users.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{User}"/> containing the list of users.</returns>
        public Task<IPagedList<User>> GetAllAsync(GetUsersRequest request, PaginationInfo pagination)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            return Connection.GetAsync<IPagedList<User>>("users", null,
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
                }, null, new PagedListConverter<User>("users"));
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
        /// <returns>The <see cref="User"/> that was requested.</returns>
        public Task<User> GetAsync(string id, string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<User>($"users/{id}", null,
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                }, null, null);
        }

        /// <summary>
        /// Retrieve every log event for a specific user.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying logs for a user.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{LogEntry}"/> containing the log entries for the user.</returns>
        public Task<IPagedList<LogEntry>> GetLogsAsync(GetUserLogsRequest request, PaginationInfo pagination)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            return Connection.GetAsync<IPagedList<LogEntry>>($"users/{request.UserId}/logs", null,
                new Dictionary<string, string>
                {
                    {"sort", request.Sort},
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }, null, new PagedListConverter<LogEntry>("logs", true));
        }

        /// <summary>
        /// Retrieve assigned roles for a specific user.
        /// </summary>
        /// <param name="userId">The user id of the roles to retrieve.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{Role}"/> containing the roles for the user.</returns>
        public Task<IPagedList<Role>> GetRolesAsync(string userId, PaginationInfo pagination)
        {
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            return Connection.GetAsync<IPagedList<Role>>($"users/{userId}/roles", null,
                new Dictionary<string, string>
                {
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }, null, new PagedListConverter<Role>("roles"));
        }

        /// <summary>
        /// Gets all users by email address.
        /// </summary>
        /// <param name="email">The email address to search for.</param>
        /// <param name="fields"> A comma separated list of fields to include or exclude (depending on <see cref="includeFields"/>) from the result, null to retrieve all fields.</param>
        /// <param name="includeFields">true if the fields specified are to be included in the result, false otherwise. Defaults to true.</param>
        /// <returns>A <see cref="IList{User}"/> containing all users for this email address.</returns>
        public Task<IList<User>> GetUsersByEmailAsync(string email, string fields = null, bool? includeFields = null)
        {
            return Connection.GetAsync<IList<User>>("users-by-email", null,
                new Dictionary<string, string>
                {
                    {"email", email},
                    {"fields", fields},
                    {"include_fields", includeFields?.ToString().ToLower()}
                }, null, null);
        }

        /// <summary>
        /// Get a list of Guardian enrollments.
        /// </summary>
        /// <param name="id">The user_id of the user to retrieve.</param>
        /// <returns>A Task representing the operation and potential return value.</returns>
        public Task<IList<EnrollmentsResponse>> GetEnrollmentsAsync(string id)
        {
            return Connection.GetAsync<IList<EnrollmentsResponse>>($"users/{id}/enrollments");
        }

        /// <summary>
        /// Invalidate all remembered browsers for MFA.
        /// </summary>
        /// <param name="id">The user_id of the user which will have its remembered browsers for MFA invalidated.</param>
        /// <returns>A Task representing the operation and potential return value.</returns>
        public Task InvalidateRememberBrowserAsync(string id)
        {
            return Connection.RunAsync<object>(HttpMethod.Post, $"users/{id}/multifactor/actions/invalidate-remember-browser");
        }

        /// <summary>
        /// Generate new Guardian recovery code.
        /// </summary>
        /// <param name="id">The user_id of the user which guardian code will be regenerated.</param>
        /// <returns>A Task representing the operation and potential return value.</returns>
        public Task<GenerateRecoveryCodeResponse> GenerateRecoveryCodeAsync(string id)
        {
            return Connection.RunAsync<GenerateRecoveryCodeResponse>(HttpMethod.Post, $"users/{id}/recovery-code-regeneration");
        }

        /// <summary>
        /// Links a secondary account to a primary account.
        /// </summary>
        /// <param name="id">The ID of the primary account.</param>
        /// <param name="request">The <see cref="UserAccountLinkRequest" /> containing details of the secondary account to link.</param>
        /// <returns>A <see cref="IList{AccountLinkResponse}"/> containing details about this account link.</returns>
        public Task<IList<AccountLinkResponse>> LinkAccountAsync(string id, UserAccountLinkRequest request)
        {
            return Connection.RunAsync<IList<AccountLinkResponse>>(HttpMethod.Post, $"users/{id}/identities", request);
        }

        /// <summary>
        /// Links a secondary account to a primary account.
        /// </summary>
        /// <param name="id">The ID of the primary account.</param>
        /// <param name="primaryJwtToken">The JWT of the primary account.</param>
        /// <param name="secondaryJwtToken">The JWT for the secondary account you wish to link.</param>
        /// <returns>A <see cref="IList{AccountLinkResponse}"/> containing details about this account link.</returns>
        public Task<IList<AccountLinkResponse>> LinkAccountAsync(string id, string primaryJwtToken, string secondaryJwtToken)
        {
            var request = new UserAccountJwtLinkRequest
            {
                LinkWith = secondaryJwtToken
            };

            return Connection.RunAsync<IList<AccountLinkResponse>>(HttpMethod.Post, $"users/{id}/identities", request, null, null, null, new Dictionary<string, object>
            {
                {"Authorization", $"Bearer {primaryJwtToken}"}
            });
        }

        /// <summary>
        /// Removes Roles from a user.
        /// </summary>
        /// <param name="id">The ID of the user to remove roles from.</param>
        /// <param name="request">A <see cref="AssignRolesRequest" /> containing the role IDs to remove to the user.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous remove operation.</returns>
        public Task RemoveRolesAsync(string id, AssignRolesRequest request)
        {
            return Connection.DeleteAsync<object>($"users/{id}/roles", request);
        }

        /// <summary>
        /// Unlinks user accounts
        /// </summary>
        /// <param name="primaryUserId">The ID of the primary account.</param>
        /// <param name="provider">The type of the identity provider.</param>
        /// <param name="secondaryUserId">The ID for the secondary account.</param>
        /// <returns>A <see cref="IList{AccountLinkResponse}"/> containing details about this account link.</returns>
        public Task<IList<AccountLinkResponse>> UnlinkAccountAsync(string primaryUserId, string provider, string secondaryUserId)
        {
            return Connection.DeleteAsync<IList<AccountLinkResponse>>($"users/{primaryUserId}/identities/{provider}/{secondaryUserId}");
        }

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="id">The id of the user to update.</param>
        /// <param name="request">The <see cref="UserUpdateRequest" /> containing the information you wish to update.</param>
        /// <returns>The newly updated <see cref="User"/>.</returns>
        public Task<User> UpdateAsync(string id, UserUpdateRequest request)
        {
            return Connection.PatchAsync<User>($"users/{id}", request);
        }

        /// <summary>
        /// Get the permissions assigned to the user.
        /// </summary>
        /// <param name="id">The id of the user to obtain the permissions for.</param>
        /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{Permission}"/> containing the assigned permissions for this user.</returns>
        public Task<IPagedList<Permission>> GetPermissionsAsync(string id, PaginationInfo pagination)
        {
            return Connection.GetAsync<IPagedList<Permission>>($"users/{id}/permissions", null,
                new Dictionary<string, string>
                {
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }, null, new PagedListConverter<Permission>("permissions"));
        }

        /// <summary>
        /// Assign permissions to a user.
        /// </summary>
        /// <param name="id">The ID of the user to assign permissions to.</param>
        /// <param name="request">A <see cref="AssignPermissionsRequest" /> containing the permission identifiers to assign to the user.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous assignment operation.</returns>
        public Task AssignPermissionsAsync(string id, AssignPermissionsRequest request)
        {
            return Connection.RunAsync<object>(HttpMethod.Post, $"users/{id}/permissions", request);
        }

        /// <summary>
        /// Removes permissions assigned to a user.
        /// </summary>
        /// <param name="id">The ID of the user to remove permissions from.</param>
        /// <param name="request">A <see cref="AssignPermissionsRequest" /> containing the permission identifiers to remove from the user.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous remove operation.</returns>
        public Task RemovePermissionsAsync(string id, AssignPermissionsRequest request)
        {
            return Connection.DeleteAsync<object>($"users/{id}/permissions", request);
        }
    }
}
