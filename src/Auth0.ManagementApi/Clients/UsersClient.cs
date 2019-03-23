using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Serialization;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /users endpoints.
    /// </summary>
    public class UsersClient : ClientBase, IUsersClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersClient"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public UsersClient(ApiConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public Task AssignRolesAsync(string id, AssignRolesRequest request)
        {
            return Connection.PostAsync<AssignUsersRequest>("users/{id}/roles", request, null, null,
                new Dictionary<string, string>
                {
                    {"id", id},
                }, null, null);
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="request">The <see cref="UserCreateRequest" /> containing the properties of the user to create.</param>
        /// <returns>Task&lt;User&gt;.</returns>
        public Task<User> CreateAsync(UserCreateRequest request)
        {
            return Connection.PostAsync<User>("users", request, null, null, null, null, null);
        }


        /// <summary>
        /// Deletes all users. Use with caution!
        /// </summary>
        /// <returns>Task.</returns>
        public Task DeleteAllAsync()
        {
            return Connection.DeleteAsync<object>("users", null, null);
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="id">The id of the user to delete.</param>
        /// <returns>Task.</returns>
        public Task DeleteAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(id));

            return Connection.DeleteAsync<object>("users/{id}", new Dictionary<string, string>
            {
                {"id", id}
            }, null);
        }

        /// <summary>
        ///     Deletes a user's multifactor provider.
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

        /// <inheritdoc />
        [Obsolete("Use GetAllAsync(GetUsersRequest) or GetAllAsync(GetUsersRequest, PaginationInfo) instead")]
        public Task<IPagedList<User>> GetAllAsync(int? page = null,
            int? perPage = null,
            bool? includeTotals = null,
            string sort = null,
            string connection = null,
            string fields = null,
            bool? includeFields = null,
            string q = null,
            string searchEngine = null)
        {
            return Connection.GetAsync<IPagedList<User>>("users", null,
                new Dictionary<string, string>
                {
                    {"page", page?.ToString()},
                    {"per_page", perPage?.ToString()},
                    {"include_totals", includeTotals?.ToString().ToLower()},
                    {"sort", sort},
                    {"connection", connection},
                    {"fields", fields},
                    {"include_fields", includeFields?.ToString().ToLower()},
                    {"q", q},
                    {"search_engine", searchEngine}
                }, null, new PagedListConverter<User>("users"));
        }

        /// <inheritdoc />
        public Task<IPagedList<User>> GetAllAsync(GetUsersRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return Connection.GetAsync<IPagedList<User>>("users", null,
                new Dictionary<string, string>
                {
                    {"sort", request.Sort},
                    {"connection", request.Connection},
                    {"fields", request.Fields},
                    {"include_fields", request.IncludeFields?.ToString().ToLower()},
                    {"q", request.Query},
                    {"search_engine", request.SearchEngine}
                }, null, new PagedListConverter<User>("users"));
        }

        /// <inheritdoc />
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
        /// <param name="fields">A comma separated list of fields to include or exclude (depending on includeFields) from the
        /// result, empty to retrieve all fields</param>
        /// <param name="includeFields">true if the fields specified are to be included in the result, false otherwise (defaults to
        /// true)</param>
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
        /// Retrieve every log event for a specific user id
        /// </summary>
        /// <param name="userId">The user id of the logs to retrieve</param>
        /// <param name="page">The zero-based page number</param>
        /// <param name="perPage">The amount of entries per page. Default: 50. Max value: 100</param>
        /// <param name="sort">The field to use for sorting. Use field:order where order is 1 for ascending and -1 for descending. For example date:-1</param>
        /// <param name="includeTotals">True if a query summary must be included in the result, false otherwise. Default false.</param>
        /// <returns></returns>
        [Obsolete("Use GetLogsAsync(GetUserLogsRequest) or GetLogsAsync(GetUserLogsRequest, PaginationInfo) instead")]
        public Task<IPagedList<LogEntry>> GetLogsAsync(string userId, int? page = null, int? perPage = null, string sort = null, bool? includeTotals = null)
        {
            return Connection.GetAsync<IPagedList<LogEntry>>("users/{id}/logs",
                new Dictionary<string, string>
                {
                    {"id", userId}
                },
                new Dictionary<string, string>
                {
                    {"page", page?.ToString()},
                    {"per_page", perPage?.ToString()},
                    {"sort", sort},
                    {"include_totals", includeTotals?.ToString().ToLower()}
                }, null, new PagedListConverter<LogEntry>("logs", true));
        }

        /// <inheritdoc />
        public Task<IPagedList<LogEntry>> GetLogsAsync(GetUserLogsRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return Connection.GetAsync<IPagedList<LogEntry>>("users/{id}/logs",
                new Dictionary<string, string>
                {
                    {"id", request.UserId}
                },
                new Dictionary<string, string>
                {
                    {"sort", request.Sort}
                }, null, new PagedListConverter<LogEntry>("logs", true));
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public Task<IPagedList<Role>> GetRolesAsync(string userId)
        {
            return Connection.GetAsync<IPagedList<Role>>("users/{userId}/roles",
                new Dictionary<string, string>
                {
                    {"userId", userId}
                }, null, null, new PagedListConverter<Role>("roles"));
        }

        /// <inheritdoc />
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
        /// <returns>Task&lt;IList&lt;AccountLinkResponse&gt;&gt;.</returns>
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
        /// <returns>Task&lt;IList&lt;AccountLinkResponse&gt;&gt;.</returns>
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


        /// <inheritdoc />
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
        /// <returns>Task&lt;IList&lt;AccountLinkResponse&gt;&gt;.</returns>
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
        /// <returns>Task&lt;User&gt;.</returns>
        public Task<User> UpdateAsync(string id, UserUpdateRequest request)
        {
            return Connection.PatchAsync<User>("users/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }
    }
}
