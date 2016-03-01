using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /clients endpoints.
    /// </summary>
    public class ClientsClient : ClientBase, IClientsClient
    {
        /// <summary>
        /// Creates a new instance of the ClientBase class.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public ClientsClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Creates a new client application.
        /// </summary>
        /// <param name="request">The request containing the properties of the new client.</param>
        /// <returns>Task&lt;Core.Client&gt;.</returns>
        public Task<Core.Client> CreateAsync(ClientCreateRequest request)
        {
            return Connection.PostAsync<Core.Client>("clients", request, null, null, null, null, null);
        }

        /// <summary>
        /// Deletes a client and all its related assets (like rules, connections, etc) given its id.
        /// </summary>
        /// <param name="id">The id of the client to delete.</param>
        /// <returns>Task.</returns>
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>("clients/{id}", new Dictionary<string, string>
            {
                {"id", id}
            });
        }

        /// <summary>
        /// Retrieves a client by its id.
        /// </summary>
        /// <param name="id">The id of the client to retrieve</param>
        /// <param name="fields">A comma separated list of fields to include or exclude (depending on includeFields) from the
        /// result, empty to retrieve all fields</param>
        /// <param name="includeFields">true if the fields specified are to be included in the result, false otherwise (defaults to
        /// true)</param>
        /// <returns>Task&lt;Core.Client&gt;.</returns>
        public Task<Core.Client> GetAsync(string id, string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<Core.Client>("clients/{id}",
                new Dictionary<string, string>
                {
                    {"id", id}
                },
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                }, null, null);
        }

        /// <summary>
        /// Retrieves a list of all client applications. Accepts a list of fields to include or exclude.
        /// </summary>
        /// <param name="fields">A comma separated list of fields to include or exclude (depending on includeFields) from the
        /// result, empty to retrieve all fields</param>
        /// <param name="includeFields">true if the fields specified are to be included in the result, false otherwise (defaults to
        /// true)</param>
        /// <returns>Task&lt;IList&lt;Core.Client&gt;&gt;.</returns>
        public Task<IList<Core.Client>> GetAllAsync(string fields = null, bool includeFields = true)
        {
            return Connection.GetAsync<IList<Core.Client>>("clients", null,
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()}
                }, null, null);
        }

        /// <summary>
        /// Updates a client application.
        /// </summary>
        /// <param name="id">The id of the client you want to update.</param>
        /// <param name="request">The request containing the properties of the client you want to update.</param>
        /// <returns>Task&lt;Core.Client&gt;.</returns>
        public Task<Core.Client> UpdateAsync(string id, ClientUpdateRequest request)
        {
            return Connection.PatchAsync<Core.Client>("clients/{id}", request, new Dictionary<string, string>
            {
                {"id", id}
            });
        }

        #region Obsolete Methods
#pragma warning disable 1591

        [Obsolete("Use CreateAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task<Core.Client> Create(ClientCreateRequest request)
        {
            return CreateAsync(request);
        }

        [Obsolete("Use DeleteAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task Delete(string id)
        {
            return DeleteAsync(id);
        }

        [Obsolete("Use GetAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task<Core.Client> Get(string id, string fields = null, bool includeFields = true)
        {
            return GetAsync(id, fields, includeFields);
        }

        [Obsolete("Use GetAllAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task<IList<Core.Client>> GetAll(string fields = null, bool includeFields = true)
        {
            return GetAllAsync(fields, includeFields);
        }

        [Obsolete("Use UpdateAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task<Core.Client> Update(string id, ClientUpdateRequest request)
        {
            return UpdateAsync(id, request);
        }

#pragma warning restore 1591
        #endregion
    }
}