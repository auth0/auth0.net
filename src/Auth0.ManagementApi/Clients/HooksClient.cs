using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /hooks endpoints.
    /// </summary>
    public class HooksClient : BaseClient, IHooksClient
    {
        readonly JsonConverter[] hooksConverters = new JsonConverter[] { new PagedListConverter<Hook>("hooks") };

        /// <summary>
        /// Initializes a new instance of <see cref="HooksClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public HooksClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders) : base(connection, baseUri, defaultHeaders)
        {

        }

        /// <summary>
        /// Creates a new hook according to the request.
        /// </summary>
        /// <param name="request">The <see cref="HookCreateRequest" /> containing the details of the hook to create.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The newly created <see cref="Hook" />.</returns>
        public Task<Hook> CreateAsync(HookCreateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Hook>(HttpMethod.Post, BuildUri("hooks"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Deletes a hook.
        /// </summary>
        /// <param name="id">The ID of the hook to delete.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"hooks/{EncodePath(id)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieves a list of all hooks.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying hooks.</param>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IPagedList{T}"/> containing the hooks requested.</returns>
        public Task<IPagedList<Hook>> GetAllAsync(GetHooksRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var queryStrings = new Dictionary<string, string>
            {
                {"enabled", request.Enabled?.ToString().ToLower()},
                {"fields", request.Fields},
                {"triggerId", request.TriggerId},
            };

            if (pagination != null)
            {
                queryStrings["page"] = pagination.PageNo.ToString();
                queryStrings["per_page"] = pagination.PerPage.ToString();
                queryStrings["include_totals"] = pagination.IncludeTotals.ToString().ToLower();
            }

            return Connection.GetAsync<IPagedList<Hook>>(BuildUri("hooks",
                queryStrings), DefaultHeaders, hooksConverters, cancellationToken);
        }

        /// <summary>
        /// Retrieves a hook by its ID.
        /// </summary>
        /// <param name="id">The ID of the hook to retrieve.</param>
        /// <param name="fields">
        /// A comma separated list of fields to include, empty to retrieve all fields.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="Hook" /> that was requested.</returns>
        public Task<Hook> GetAsync(string id, string fields = null, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<Hook>(BuildUri($"hooks/{EncodePath(id)}",
                new Dictionary<string, string>
                {
                    {"fields", fields},
                }), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Updates a hook.
        /// </summary>
        /// <param name="id">The ID of the hook to update.</param>
        /// <param name="request">A <see cref="HookUpdateRequest" /> containing the information to update.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The newly updated <see cref="Hook"/>.</returns>
        public Task<Hook> UpdateAsync(string id, HookUpdateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Hook>(new HttpMethod("PATCH"), BuildUri($"hooks/{EncodePath(id)}"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}
