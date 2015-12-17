using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

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

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="request">The <see cref="UserCreateRequest" /> containing the properties of the user to create.</param>
        /// <returns>Task&lt;User&gt;.</returns>
        public Task<User> Create(UserCreateRequest request)
        {
            return Connection.PostAsync<User>("users", request, null, null, null, null, null);
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="id">The id of the user to delete.</param>
        /// <returns>Task.</returns>
        public Task Delete(string id)
        {
            return Connection.DeleteAsync<object>("users/{id}", new Dictionary<string, string>
            {
                {"id", id}
            });
        }

        /// <summary>
        /// Deletes all users. Use with caution!
        /// </summary>
        /// <returns>Task.</returns>
        public Task DeleteAll()
        {
            return Connection.DeleteAsync<object>("users", null);
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
        public Task<User> Get(string id, string fields = null, bool includeFields = true)
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
                }, null);
        }

        /// <summary>
        /// Lists or search for users based on criteria.
        /// </summary>
        /// <param name="page">The page number. Zero based.</param>
        /// <param name="perPage">The amount of entries per page.</param>
        /// <param name="includeTotals">True if a query summary must be included in the result.</param>
        /// <param name="sort">The field to use for sorting. 1 == ascending and -1 == descending</param>
        /// <param name="connection">Connection filter.</param>
        /// <param name="fields">A comma separated list of fields to include or exclude (depending on
        /// <paramref name="includeFields" />) from the result, empty to retrieve all fields.</param>
        /// <param name="includeFields">True if the fields specified are to be included in the result, false otherwise. Defaults to
        /// true.</param>
        /// <param name="q">Query in Lucene query string syntax. Only fields in app_metadata, user_metadata or the normalized user
        /// profile are searchable.</param>
        /// <param name="searchEngine">Use 'v2' if you want to try the new search engine, or 'v1' for the old search engine.</param>
        /// <returns>Task&lt;IList&lt;User&gt;&gt;.</returns>
        public Task<IList<User>> GetAll(int? page = null, int? perPage = null, bool? includeTotals = null, string sort = null, string connection = null, string fields = null,
            bool? includeFields = null,
            string q = null, string searchEngine = null)
        {
            return Connection.GetAsync<IList<User>>("users", null,
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
                }, null);
        }

        /// <summary>
        /// Unlinks user accounts
        /// </summary>
        /// <param name="primaryUserId">The ID of the primary account.</param>
        /// <param name="provider">The type of the identity provider.</param>
        /// <param name="secondaryUserId">The ID for the secondary account</param>
        /// <returns>Task&lt;IList&lt;AccountLinkResponse&gt;&gt;.</returns>
        public Task<IList<AccountLinkResponse>> UnlinkAccount(string primaryUserId, string provider, string secondaryUserId)
        {
            return Connection.DeleteAsync<IList<AccountLinkResponse>>("users/{id}/identities/{provider}/{secondaryid}", new Dictionary<string, string>
            {
                {"id", primaryUserId},
                {"provider", provider},
                {"secondaryid", secondaryUserId}
            });
        }

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="id">The id of the user to update.</param>
        /// <param name="request">The <see cref="UserUpdateRequest" /> containing the information you wish to update.</param>
        /// <returns>Task&lt;User&gt;.</returns>
        public Task<User> Update(string id, UserUpdateRequest request)
        {
            return Connection.PatchAsync<User>("users/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }

        /// <summary>
        /// Links a secondary account to a primary account.
        /// </summary>
        /// <param name="id">The ID of the primary account.</param>
        /// <param name="request">The <see cref="UserAccountLinkRequest" /> containing details of the secondary account to link.</param>
        /// <returns>Task&lt;IList&lt;AccountLinkResponse&gt;&gt;.</returns>
        public Task<IList<AccountLinkResponse>> LinkAccount(string id, UserAccountLinkRequest request)
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
        public Task<IList<AccountLinkResponse>> LinkAccount(string id, string primaryJwtToken, string secondaryJwtToken)
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
                {"Authorization", string.Format("Bearer {0}", primaryJwtToken)}
            }, null);
        }
    }
}