using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Models;
using PortableRest;

namespace Auth0.Api.Management.Clients
{
    public class ClientsClient : IClientsClient
    {
        private readonly IApiConnection apiConnection;

        public ClientsClient(IApiConnection apiConnection)
        {
            this.apiConnection = apiConnection;
        }

        public Task<IList<Client>> GetAll(string fields = null, bool includeFields = true)
        {
            return apiConnection.GetAsync<IList<Client>>("clients", null, null);
        }

        public Task<Client> Update(string id, ClientUpdateRequest request)
        {
            return apiConnection.PatchAsync<Client>("clients/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }

        public Task<Client> Create(ClientCreateRequest request)
        {
            return apiConnection.PostAsync<Client>("clients", request);
        }

        public Task Delete(string id)
        {
            return apiConnection.DeleteAsync<object>("clients/{id}", new Dictionary<string, string>
            {
                {"id", id}
            });
        }

        public Task<Client> Get(string id, string fields = null, bool includeFields = true)
        {
            return apiConnection.GetAsync<Client>("clients/{id}", new Dictionary<string, string>
            {
                { "id" , id }
            }, null);
        }
    }
}