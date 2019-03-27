using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Serialization;

namespace Auth0.ManagementApi.Clients
{
    /// <inheritdoc />
    public class UsersClient : ClientBase, IUsersClient
    {
        /// <summary>
        /// Creates a new instance of <see cref="UsersClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public UsersClient(ApiConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public Task AssignRolesAsync(string id, AssignRolesRequest request)
        {
            return Connection.PostAsync<AssignRolesRequest>("users/{id}/roles", request, null, null,
                new Dictionary<string, string>
                {
                    {"id", id},
                }, null, null);
        }

        /// <inheritdoc />
        public Task<User> CreateAsync(UserCreateRequest request)
        {
            return Connection.PostAsync<User>("users", request, null, null, null, null, null);
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
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

        /// <inheritdoc />
        public Task<IList<AccountLinkResponse>> LinkAccountAsync(string id, UserAccountLinkRequest request)
        {
            return Connection.PostAsync<IList<AccountLinkResponse>>("users/{id}/identities", request, null, null, new Dictionary<string, string>
            {
                {"id", id}
            }, null, null);
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public Task<IList<AccountLinkResponse>> UnlinkAccountAsync(string primaryUserId, string provider, string secondaryUserId)
        {
            return Connection.DeleteAsync<IList<AccountLinkResponse>>("users/{id}/identities/{provider}/{secondaryid}", new Dictionary<string, string>
            {
                {"id", primaryUserId},
                {"provider", provider},
                {"secondaryid", secondaryUserId}
            }, null);
        }

        /// <inheritdoc />
        public Task<User> UpdateAsync(string id, UserUpdateRequest request)
        {
            return Connection.PatchAsync<User>("users/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }
    }
}
