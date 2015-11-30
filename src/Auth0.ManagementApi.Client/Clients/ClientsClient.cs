using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Models;
using PortableRest;

namespace Auth0.ManagementApi.Client.Clients
{
    /// <summary>
    /// Contains all the methods to call the /clients endpoints.
    /// </summary>
    public class ClientsClient : ClientBase, IClientsClient
    {
        public ClientsClient(IApiConnection connection)
            : base(connection)
        {
        }

        public Task<Core.Models.Client> Create(ClientCreateRequest request)
        {
            return Connection.PostAsync<Core.Models.Client>("clients", ContentTypes.Json, request, null, null, null, null, null);
        }

        public Task Delete(string id)
        {
            return Connection.DeleteAsync<object>("clients/{id}", new Dictionary<string, string>
            {
                {"id", id}
            });
        }

        public Task<Core.Models.Client> Get(string id, string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<Core.Models.Client>("clients/{id}",
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

        public Task<IList<Core.Models.Client>> GetAll(string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<IList<Core.Models.Client>>("clients", null,
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                });
        }

        // TODO: Look at making fields Nullable, otherwise default values are sent during PATCH
        public Task<Core.Models.Client> Update(string id, ClientUpdateRequest request)
        {
            return Connection.PatchAsync<Core.Models.Client>("clients/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }
    }
}