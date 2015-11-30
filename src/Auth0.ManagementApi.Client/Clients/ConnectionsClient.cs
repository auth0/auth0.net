using Auth0.Core;
using Auth0.ManagementApi.Client.Models;
using PortableRest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Client.Clients
{
    public class ConnectionsClient : ClientBase, IConnectionsClient
    {
        public ConnectionsClient(IApiConnection connection)
            : base(connection)
        {
        }

        public Task<Connection> Create(ConnectionCreateRequest request)
        {
            return Connection.PostAsync<Connection>("connections", ContentTypes.Json, request, null, null, null, null);
        }

        public Task Delete(string id)
        {
            return Connection.DeleteAsync<object>("connections/{id}", new Dictionary<string, string>
            {
                {"id", id}
            });
        }

        public Task<Connection> Get(string id, string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<Connection>("connections/{id}",
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
            return Connection.GetAsync<IList<Connection>>("connections", null, 
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
            return Connection.PatchAsync<Connection>("connections/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }
    }
}