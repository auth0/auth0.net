using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all methods to work with Client Grants.
    /// </summary>
    public class ClientGrantsClient : ClientBase, IClientGrantsClient
    {
        /// <summary>
        /// Creates a new instance of the Client Grants client.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public ClientGrantsClient(ApiConnection connection) 
            : base(connection)
        {
        }

        /// <summary>
        /// Creates a new Client Grant
        /// </summary>
        /// <param name="request">The request containing the properties of the Client Grant.</param>
        /// <returns>The new <see cref="ClientGrant"/></returns>
        public Task<ClientGrant> CreateAsync(ClientGrantCreateRequest request)
        {
            return Connection.PostAsync<ClientGrant>("client-grants", request, null, null, null, null, null);

        }

        /// <summary>
        /// Deletes a client grant.
        /// </summary>
        /// <param name="id">The identifier of the Client Grant to delete.</param>
        /// <returns></returns>
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>("client-grants/{id}", new Dictionary<string, string>
            {
                {"id", id}
            }, null);
        }

        /// <summary>
        /// Gets a list of all the client grants.
        /// </summary>
        /// <param name="audience">The audience according to which you want to filter the returned client grants.</param>
        /// <returns>A list of client grants</returns>
        public Task<IList<ClientGrant>> GetAllAsync(string audience = null)
        {
            return Connection.GetAsync<IList<ClientGrant>>("client-grants", null,
                new Dictionary<string, string>
                {
                    {"audience", audience}
                }, null, null);
        }

        /// <summary>
        /// Updates a client grant
        /// </summary>
        /// <param name="id">The identifier of the client grant to update.</param>
        /// <param name="request">The <see cref="ClientGrantUpdateRequest"/> containing the properties to update.</param>
        /// <returns></returns>
        public Task<ClientGrant> UpdateAsync(string id, ClientGrantUpdateRequest request)
        {
            return Connection.PatchAsync<ClientGrant>("client-grants/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }
    }
}