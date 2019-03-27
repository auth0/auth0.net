using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Serialization;

namespace Auth0.ManagementApi.Clients
{
    /// <inheritdoc />
    public class ClientGrantsClient : ClientBase, IClientGrantsClient
    {
        /// <summary>
        /// Creates a new instance of <see cref="ClientGrantsClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public ClientGrantsClient(ApiConnection connection) 
            : base(connection)
        {
        }

        /// <inheritdoc />
        public Task<ClientGrant> CreateAsync(ClientGrantCreateRequest request)
        {
            return Connection.PostAsync<ClientGrant>("client-grants", request, null, null, null, null, null);
        }

        /// <inheritdoc />
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>("client-grants/{id}", 
                new Dictionary<string, string>
                {
                    {"id", id}
                }, null);
        }

        /// <inheritdoc />
        public Task<IPagedList<ClientGrant>> GetAllAsync(GetClientGrantsRequest request, PaginationInfo pagination)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            return Connection.GetAsync<IPagedList<ClientGrant>>("client-grants", null,
                new Dictionary<string, string>
                {
                    {"audience", request.Audience},
                    {"client_id", request.ClientId},
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }, null, new PagedListConverter<ClientGrant>("client_grants"));
        }

        /// <inheritdoc />
        public Task<ClientGrant> UpdateAsync(string id, ClientGrantUpdateRequest request)
        {
            return Connection.PatchAsync<ClientGrant>("client-grants/{id}", request, 
                new Dictionary<string, string>
                {
                    {"id", id}
                });
        }
    }
}