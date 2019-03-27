using Auth0.Core.Collections;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Serialization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all methods to call the /client-grants endpoints.
    /// </summary>
    public class ClientGrantsClient : ClientBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="ClientGrantsClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public ClientGrantsClient(ApiConnection connection) 
            : base(connection)
        {
        }

        /// <summary>
        /// Creates a new client grant.
        /// </summary>
        /// <param name="request">The <see cref="ClientGrantCreateRequest"/> containing the properties of the Client Grant.</param>
        /// <returns>The new <see cref="ClientGrant"/> that has been created.</returns>
        public Task<ClientGrant> CreateAsync(ClientGrantCreateRequest request)
        {
            return Connection.PostAsync<ClientGrant>("client-grants", request, null, null, null, null, null);
        }

        /// <summary>
        /// Deletes a client grant.
        /// </summary>
        /// <param name="id">The identifier of the Client Grant to delete.</param>
        /// <returns>A <see cref="Task"/> indicating the request completion.</returns>
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>("client-grants/{id}", 
                new Dictionary<string, string>
                {
                    {"id", id}
                }, null);
        }

        /// <summary>
        /// Gets a list of all the client grants.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying client grants.</param>
        /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
        /// <returns>A <see cref="IPagedList"/> containing the matching <see cref="ClientGrant"/> instances.</returns>
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

        /// <summary>
        /// Updates a client grant.
        /// </summary>
        /// <param name="id">The identifier of the client grant to update.</param>
        /// <param name="request">The <see cref="ClientGrantUpdateRequest"/> containing the properties to update.</param>
        /// <returns>The <see cref="ClientGrant"/> that has been updated.</returns>
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