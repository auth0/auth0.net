using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Models;

namespace Auth0.Api.Management.Clients
{
    public class ConnectionsClient : IConnectionsClient
    {
        private readonly IApiConnection apiConnection;

        public ConnectionsClient(IApiConnection apiConnection)
        {
            this.apiConnection = apiConnection;
        }

        public Task<Connection> Create(ConnectionCreateRequest request)
        {
            return apiConnection.PostAsync<Connection>("connections", request);
        }

        public Task Delete(string id)
        {
            return apiConnection.DeleteAsync<object>("connections/{id}", new Dictionary<string, string>
            {
                {"id", id}
            });
        }

        public Task<Connection> Get(string id, string fields = null, bool includeFields = true)
        {
            return apiConnection.GetAsync<Connection>("connections/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                },
                new Dictionary<string, string>
                {
                    { "fields", fields },
                    { "include_fields", includeFields.ToString().ToLower() }
                });
        }

        public Task<IList<Connection>> GetAll(string strategy, string fields = null, bool includeFields = true)
        {
            return apiConnection.GetAsync<IList<Connection>>("connections", null, 
                new Dictionary<string, string>
                {
                    { "strategy", strategy },
                    { "fields", fields },
                    { "include_fields", includeFields.ToString().ToLower() }
                });
        }

        // TODO: Look at making fields Nullable, otherwise default values are sent during PATCH
        public Task<Connection> Update(string id, ConnectionUpdateRequest request)
        {
            return apiConnection.PatchAsync<Connection>("connections/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }
    }
}