using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.Core.Http;
using Auth0.ManagementApi.Client.Models;

namespace Auth0.ManagementApi.Client.Clients
{
    public class UsersClient : ClientBase, IUsersClient
    {
        public UsersClient(ApiConnection connection)
            : base(connection)
        {
        }

        public Task<User> Create(UserCreateRequest request)
        {
            return Connection.PostAsync<User>("users", request, null, null, null, null, null);
        }

        public Task Delete(string id)
        {
            return Connection.DeleteAsync<object>("users/{id}", new Dictionary<string, string>
            {
                {"id", id}
            });
        }

        public Task DeleteAll()
        {
            return Connection.DeleteAsync<object>("users", null);
        }

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

        public Task<IList<AccountLinkResponse>> UnlinkAccount(string primaryUserId, string provider, string secondaryUserId)
        {
            return Connection.DeleteAsync<IList<AccountLinkResponse>>("users/{id}/identities/{provider}/{secondaryid}", new Dictionary<string, string>
            {
                {"id", primaryUserId},
                {"provider", provider},
                {"secondaryid", secondaryUserId}
            });
        }

        // TODO: Look at making fields Nullable, otherwise default values are sent during PATCH
        public Task<User> Update(string id, UserUpdateRequest request)
        {
            return Connection.PatchAsync<User>("users/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }

        public Task<IList<AccountLinkResponse>> LinkAccount(string id, UserAccountLinkRequest request)
        {
            return Connection.PostAsync<IList<AccountLinkResponse>>("users/{id}/identities", request, null, null, new Dictionary<string, string>
            {
                {"id", id}
            }, null, null);
        }

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

        public Task DeleteMultifactorProvider(string id, string provider)
        {
            return Connection.DeleteAsync<User>("users/{id}/multifactor/{provider}",
                new Dictionary<string, string>
                {
                    {"id", id},
                    {"provider", provider},
                });
        }
    }
}