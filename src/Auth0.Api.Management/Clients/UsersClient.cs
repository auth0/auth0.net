using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Models;

namespace Auth0.Api.Management.Clients
{
    public class UsersClient : ClientBase, IUsersClient
    {
        public UsersClient(ApiConnection connection)
            : base(connection)
        {
        }

        public Task<User> Create(UserCreateRequest request)
        {
            return Connection.PostAsync<User>("users", request, null);
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
                });
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

        public Task LinkAccount(string id, UserAccountLinkRequest request)
        {
            return Connection.PostAsync<User>("users/{id}/identities", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }

        public Task LinkAccount(string id, string primaryJwtToken, string secondaryJwtToken)
        {
            throw new NotImplementedException();
        }
    }
}