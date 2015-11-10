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
    }
}