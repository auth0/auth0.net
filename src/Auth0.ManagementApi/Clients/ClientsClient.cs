using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /clients endpoints.
    /// </summary>
    public class ClientsClient : BaseClient, IClientsClient
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
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The new <see cref="Client"/> that has been created.</returns>
        public Task<Client> CreateAsync(ClientCreateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Client>(HttpMethod.Post, BuildUri("clients"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Deletes a client and all its related assets (like rules, connections, etc) given its id.
        /// </summary>
        /// <param name="id">The id of the client to delete.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"clients/{EncodePath(id)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of all client applications.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying clients.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IPagedList{Client}"/> containing the clients.</returns>
        public Task<IPagedList<Client>> GetAllAsync(GetClientsRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var queryStrings = new Dictionary<string, string>
            {
                {"fields", request.Fields},
                {"include_fields", request.IncludeFields?.ToString().ToLower()},
                {"is_global", request.IsGlobal?.ToString().ToLower()},
                {"is_first_party", request.IsFirstParty?.ToString().ToLower()}
            };

            if (pagination != null)
            {
                queryStrings["page"] = pagination.PageNo.ToString();
                queryStrings["per_page"] = pagination.PerPage.ToString();
                queryStrings["include_totals"] = pagination.IncludeTotals.ToString().ToLower();
            }

            if (request.AppType != null)
                queryStrings.Add("app_type", string.Join(",", request.AppType.Select(ExtensionMethods.ToEnumString)));

            return Connection.GetAsync<IPagedList<Client>>(BuildUri("clients", queryStrings), DefaultHeaders, converters, cancellationToken);
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
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="Client"/> retrieved.</returns>
        public Task<Client> GetAsync(string id, string fields = null, bool includeFields = true, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<Client>(BuildUri($"clients/{EncodePath(id)}",
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                }), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Rotate a client secret. The generated secret is NOT base64 encoded.
        /// </summary>
        /// <param name="id">The id of the client which secret needs to be rotated.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="Client"/> that has had its secret rotated.</returns>
        public Task<Client> RotateClientSecret(string id, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Client>(HttpMethod.Post, BuildUri($"clients/{EncodePath(id)}/rotate-secret"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Updates a client application.
        /// </summary>
        /// <param name="id">The id of the client you want to update.</param>
        /// <param name="request">The <see cref="ClientUpdateRequest"/> containing the properties of the client you want to update.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="Client"/> that was updated.</returns>
        public Task<Client> UpdateAsync(string id, ClientUpdateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Client>(new HttpMethod("PATCH"), BuildUri($"clients/{EncodePath(id)}"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Creates a new client credential.
        /// </summary>
        /// <param name="clientId">The id of the client for which you want to create the credential.</param>
        /// <param name="request">The <see cref="ClientCredentialCreateRequest"/> containing the properties of the new client credential.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The new <see cref="Credential"/> that has been created.</returns>
        public Task<Credential> CreateCredentialAsync(string clientId, ClientCredentialCreateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Credential>(HttpMethod.Post, BuildUri($"clients/{EncodePath(clientId)}/credentials"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Update a client credential.
        /// </summary>
        /// <param name="clientId">The id of the client for which you want to update the credential.</param>
        /// <param name="credentialId">The id of the credential to update.</param>
        /// <param name="request">The <see cref="ClientCredentialUpdateRequest"/> containing the properties of the new client credential.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The new <see cref="Credential"/> that has been created.</returns>
        public Task<Credential> UpdateCredentialAsync(string clientId, string credentialId, ClientCredentialUpdateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Credential>(new HttpMethod("PATCH"), BuildUri($"clients/{EncodePath(clientId)}/credentials/{EncodePath(credentialId)}"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of all credentials for a client.
        /// </summary>
        /// <param name="clientId">The id of the client for which you want to retrieve the credentials.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IList{Credential}"/> containing the client's credentials.</returns>
        public Task<IList<Credential>> GetAllCredentialsAsync(string clientId, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<IList<Credential>>(BuildUri($"clients/{EncodePath(clientId)}/credentials"), DefaultHeaders, null, cancellationToken);
        }

        /// <summary>
        /// Retrieves a specific credential for a client.
        /// </summary>
        /// <param name="clientId">The id of the client for which you want to retrieve the credential.</param>
        /// <param name="credentialId">The id of the credential to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Credential"/> containing the client's credential.</returns>
        public Task<Credential> GetCredentialAsync(string clientId, string credentialId, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<Credential>(BuildUri($"clients/{EncodePath(clientId)}/credentials/{EncodePath(credentialId)}"), DefaultHeaders, null, cancellationToken);
        }

        /// <summary>
        /// Deletes a specific credential registered with the provided client.
        /// </summary>
        /// <param name="clientId">The id of the client for which you want to remove the credential.</param>
        /// <param name="credentialId">The id of the credential to remove.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteCredentialAsync(string clientId, string credentialId, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"clients/{EncodePath(clientId)}/credentials/{EncodePath(credentialId)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}
