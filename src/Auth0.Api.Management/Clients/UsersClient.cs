using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Models;

namespace Auth0.Api.Management.Clients
{
    public class UsersClient : IUsersClient
    {
        private readonly ApiConnection apiConnection;

        public UsersClient(ApiConnection apiConnection)
        {
            this.apiConnection = apiConnection;
        }

        public Task<User> Create(UserCreateRequest request)
        {
            return apiConnection.PostAsync<User>("users", request);
        }

        public Task Delete(string id)
        {
            return apiConnection.DeleteAsync<object>("users/{id}", new Dictionary<string, string>
            {
                {"id", id}
            });
        }

        public Task DeleteAll()
        {
            return apiConnection.DeleteAsync<object>("users", null);
        }

        public Task<User> Get(string id, string fields = null, bool includeFields = true)
        {
            return apiConnection.GetAsync<User>("users/{id}",
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
            return apiConnection.GetAsync<IList<User>>("users", null,
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
            return apiConnection.PatchAsync<User>("users/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }
    }
}