using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Models;

namespace Auth0.Api.Management.Clients
{
    public class ClientsClient : ClientBase, IClientsClient
    {
        public ClientsClient(IApiConnection connection)
            : base(connection)
        {
        }

        public Task<Client> Create(ClientCreateRequest request)
        {
            return Connection.PostAsync<Client>("clients", request);
        }

        public Task Delete(string id)
        {
            return Connection.DeleteAsync<object>("clients/{id}", new Dictionary<string, string>
            {
                {"id", id}
            });
        }

        public Task<Client> Get(string id, string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<Client>("clients/{id}",
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

        public Task<IList<Client>> GetAll(string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<IList<Client>>("clients", null,
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                });
        }

        // TODO: Look at making fields Nullable, otherwise default values are sent during PATCH
        public Task<Client> Update(string id, ClientUpdateRequest request)
        {
            return Connection.PatchAsync<Client>("clients/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }
    }
}