using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /clients endpoints.
    /// </summary>
    public class ClientsClient : BaseClient
    {
        readonly JsonConverter[] converters = new JsonConverter[] { new PagedListConverter<Client>("clients") };

        /// <summary>
        /// Initializes a new instance of <see cref="ClientsClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public ClientsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Creates a new client application.
        /// </summary>
        /// <param name="request">The <see cref="ClientCreateRequest"/> containing the properties of the new client.</param>
        /// <returns>The new <see cref="Client"/> that has been created.</returns>
        public Task<Client> CreateAsync(ClientCreateRequest request)
        {
            return Connection.SendAsync<Client>(HttpMethod.Post, BuildUri("clients"), request, DefaultHeaders);
        }

        /// <summary>
        /// Deletes a client and all its related assets (like rules, connections, etc) given its id.
        /// </summary>
        /// <param name="id">The id of the client to delete.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"clients/{id}"), null, DefaultHeaders);
        }

        /// <summary>
        /// Retrieves a list of all client applications.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying clients.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{Client}"/> containing the clients.</returns>
        public Task<IPagedList<Client>> GetAllAsync(GetClientsRequest request, PaginationInfo pagination)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            var queryStrings = new Dictionary<string, string>
            {
                {"fields", request.Fields},
                {"include_fields", request.IncludeFields?.ToString().ToLower()},
                {"is_global", request.IsGlobal?.ToString().ToLower()},
                {"is_first_party", request.IsFirstParty?.ToString().ToLower()},
                {"page", pagination.PageNo.ToString()},
                {"per_page", pagination.PerPage.ToString()},
                {"include_totals", pagination.IncludeTotals.ToString().ToLower()},
            };

            if (request.AppType != null)
                queryStrings.Add("app_type", string.Join(",", request.AppType.Select(ExtensionMethods.ToEnumString)));

            return Connection.GetAsync<IPagedList<Client>>(BuildUri("clients", queryStrings), DefaultHeaders, converters);
        }

        /// <summary>
        /// Retrieves a client by its id.
        /// </summary>
        /// <param name="id">The id of the client to retrieve.</param>
        /// <param name="fields">
        /// A comma separated list of fields to include or exclude (depending on includeFields) from the
        /// result, empty to retrieve all fields.
        /// </param>
        /// <param name="includeFields">
        /// true if the fields specified are to be included in the result, false otherwise (defaults to
        /// true)
        /// </param>
        /// <returns>The <see cref="Client"/> retrieved.</returns>
        public Task<Client> GetAsync(string id, string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<Client>(BuildUri($"clients/{id}",
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                }), DefaultHeaders);
        }

        /// <summary>
        /// Rotate a client secret. The generated secret is NOT base64 encoded.
        /// </summary>
        /// <param name="id">The id of the client which secret needs to be rotated.</param>
        /// <returns>The <see cref="Client"/> that has had its secret rotated.</returns>
        public Task<Client> RotateClientSecret(string id)
        {
            return Connection.SendAsync<Client>(HttpMethod.Post, BuildUri($"clients/{id}/rotate-secret"), null, DefaultHeaders);
        }

        /// <summary>
        /// Updates a client application.
        /// </summary>
        /// <param name="id">The id of the client you want to update.</param>
        /// <param name="request">The <see cref="ClientUpdateRequest"/> containing the properties of the client you want to update.</param>
        /// <returns>The <see cref="Client"/> that was updated.</returns>
        public Task<Client> UpdateAsync(string id, ClientUpdateRequest request)
        {
            return Connection.SendAsync<Client>(new HttpMethod("PATCH"), BuildUri($"clients/{id}"), request, DefaultHeaders);
        }
    }
}