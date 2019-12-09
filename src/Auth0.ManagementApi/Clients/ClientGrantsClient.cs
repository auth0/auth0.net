using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /client-grants endpoints.
    /// </summary>
    public class ClientGrantsClient : BaseClient
    {
        readonly JsonConverter[] converters = new JsonConverter[] { new PagedListConverter<ClientGrant>("client_grants") };

        /// <summary>
        /// Initializes a new instance of <see cref="ClientGrantsClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public ClientGrantsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders) 
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Creates a new client grant.
        /// </summary>
        /// <param name="request">The <see cref="ClientGrantCreateRequest"/> containing the properties of the Client Grant.</param>
        /// <returns>The new <see cref="ClientGrant"/> that has been created.</returns>
        public Task<ClientGrant> CreateAsync(ClientGrantCreateRequest request)
        {
            return Connection.SendAsync<ClientGrant>(HttpMethod.Post, BuildUri("client-grants"), request, DefaultHeaders);
        }

        /// <summary>
        /// Deletes a client grant.
        /// </summary>
        /// <param name="id">The identifier of the Client Grant to delete.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"client-grants/{id}"), null, DefaultHeaders); 
        }

        /// <summary>
        /// Gets a list of all the client grants.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying client grants.</param>
        /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
        /// <returns>A <see cref="IPagedList{ClientGrant}"/> containing the client grants requested.</returns>
        public Task<IPagedList<ClientGrant>> GetAllAsync(GetClientGrantsRequest request, PaginationInfo pagination)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            return Connection.GetAsync<IPagedList<ClientGrant>>(BuildUri("client-grants",
                new Dictionary<string, string>
                {
                    {"audience", request.Audience},
                    {"client_id", request.ClientId},
                    {"page", pagination.PageNo.ToString()},
                    {"per_page", pagination.PerPage.ToString()},
                    {"include_totals", pagination.IncludeTotals.ToString().ToLower()}
                }), DefaultHeaders, converters);
        }

        /// <summary>
        /// Updates a client grant.
        /// </summary>
        /// <param name="id">The identifier of the client grant to update.</param>
        /// <param name="request">The <see cref="ClientGrantUpdateRequest"/> containing the properties to update.</param>
        /// <returns>The <see cref="ClientGrant"/> that has been updated.</returns>
        public Task<ClientGrant> UpdateAsync(string id, ClientGrantUpdateRequest request)
        {
            return Connection.SendAsync<ClientGrant>(new HttpMethod("PATCH"), BuildUri($"client-grants/{id}"), request, DefaultHeaders);
        }
    }
}
