using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Serialization;
using System;
using System.Collections.Generic;
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
        public UsersClient(ApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Assigns Roles to a user.
        /// </summary>
        /// <param name="id">The ID of the user to assign roles to.</param>
        /// <param name="request">A <see cref="AssignRolesRequest" /> containing the role IDs to assign to the user.</param>
        /// <returns></returns>
        public Task AssignRolesAsync(string id, AssignRolesRequest request)
        {
            return Connection.PostAsync<AssignRolesRequest>("users/{id}/roles", request, null, null,
                new Dictionary<string, string>
                {
                    {"id", id},
                }, null, null);
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="request">The <see cref="UserCreateRequest" /> containing the properties of the user to create.</param>
        /// <returns></returns>
        public Task<User> CreateAsync(UserCreateRequest request)
        {
            return Connection.PostAsync<User>("users", request, null, null, null, null, null);
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="id">The id of the user to delete.</param>
        public Task DeleteAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

            return Connection.DeleteAsync<object>("users/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                }, null);
        }

        /// <summary>
        /// Deletes a user's multifactor provider.
        /// </summary>
        /// <param name="id">The id of the user who multi factor provider to delete.</param>
        /// <param name="provider">The type of the multifactor provider. Supported values 'duo' or 'google-authenticator'</param>
        /// <returns></returns>
        public Task DeleteMultifactorProviderAsync(string id, string provider)
        {
            return Connection.DeleteAsync<object>("users/{id}/multifactor/{provider}",
                new Dictionary<string, string>
                {
                    {"id", id},
                    {"provider", provider}
                }, null);
        }

        /// <summary>
        /// Lists or search for users based on criteria.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying users.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{GetUsersRequest}"/> containing the list of users.</returns>
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
        /// <returns>The <see cref="User" />.</returns>
        public Task<User> GetAsync(string id, string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<User>("users/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                },
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

            return Connection.GetAsync<IPagedList<LogEntry>>("users/{id}/logs",
                new Dictionary<string, string>
                {
                    {"id", request.UserId}
                },
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
        /// <param name="userId">The user id of the roles to retrieve</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{Role}"/> containing the roles for the user.</returns>
        public Task<IPagedList<Role>> GetRolesAsync(string userId, PaginationInfo pagination)
        {
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            return Connection.GetAsync<IPagedList<Role>>("users/{userId}/roles",
                new Dictionary<string, string>
                {
                    {"userId", userId}
                },
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
        /// <param name="email">The email address to search for</param>
        /// <param name="fields"> A comma separated list of fields to include or exclude (depending on <see cref="includeFields"/>) from the result, null to retrieve all fields</param>
        /// <param name="includeFields">true if the fields specified are to be included in the result, false otherwise. Defaults to true</param>
        /// <returns></returns>
        public Task<IList<User>> GetUsersByEmailAsync(string email, string fields = null, bool? includeFields = null)
        {
            return Connection.GetAsync<IList<User>>("users-by-email", null,
                new Dictionary<string, string>
                {
                    {"email", email},
                    {"fields", fields},
                    {"include_fields", includeFields?.ToString().ToLower()},
                }, null, null);
        }

        /// <summary>
        /// Links a secondary account to a primary account.
        /// </summary>
        /// <param name="id">The ID of the primary account.</param>
        /// <param name="request">The <see cref="UserAccountLinkRequest" /> containing details of the secondary account to link.</param>
        /// <returns></returns>
        public Task<IList<AccountLinkResponse>> LinkAccountAsync(string id, UserAccountLinkRequest request)
        {
            return Connection.PostAsync<IList<AccountLinkResponse>>("users/{id}/identities", request, null, null, new Dictionary<string, string>
            {
                {"id", id}
            }, null, null);
        }

        /// <summary>
        /// Links a secondary account to a primary account.
        /// </summary>
        /// <param name="id">The ID of the primary account.</param>
        /// <param name="primaryJwtToken">The JWT of the primary account.</param>
        /// <param name="secondaryJwtToken">The JWT for the secondary account you wish to link.</param>
        /// <returns></returns>
        public Task<IList<AccountLinkResponse>> LinkAccountAsync(string id, string primaryJwtToken, string secondaryJwtToken)
        {
            var request = new UserAccountJwtLinkRequest
            {
                LinkWith = secondaryJwtToken
            };

            return Connection.PostAsync<IList<AccountLinkResponse>>("users/{id}/identities", request, null, null, new Dictionary<string, string>
            {
                {"id", id}
            }, new Dictionary<string, object>
            {
                {"Authorization", $"Bearer {primaryJwtToken}"}
            }, null);
        }

        /// <summary>
        /// Removes Roles from a user.
        /// </summary>
        /// <param name="id">The ID of the user to remove roles from.</param>
        /// <param name="request">A <see cref="AssignRolesRequest" /> containing the role IDs to remove to the user.</param>
        /// <returns></returns>
        public Task RemoveRolesAsync(string id, AssignRolesRequest request)
        {
            return Connection.DeleteAsync<object>("users/{id}/roles", request, new Dictionary<string, string>
                {
                    {"id", id},
                }, null
            );
        }

        /// <summary>
        /// Unlinks user accounts
        /// </summary>
        /// <param name="primaryUserId">The ID of the primary account.</param>
        /// <param name="provider">The type of the identity provider.</param>
        /// <param name="secondaryUserId">The ID for the secondary account</param>
        /// <returns></returns>
        public Task<IList<AccountLinkResponse>> UnlinkAccountAsync(string primaryUserId, string provider, string secondaryUserId)
        {
            return Connection.DeleteAsync<IList<AccountLinkResponse>>("users/{id}/identities/{provider}/{secondaryid}", new Dictionary<string, string>
            {
                {"id", primaryUserId},
                {"provider", provider},
                {"secondaryid", secondaryUserId}
            }, null);
        }

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="id">The id of the user to update.</param>
        /// <param name="request">The <see cref="UserUpdateRequest" /> containing the information you wish to update.</param>
        /// <returns></returns>
        public Task<User> UpdateAsync(string id, UserUpdateRequest request)
        {
            return Connection.PatchAsync<User>("users/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }
    }
}
