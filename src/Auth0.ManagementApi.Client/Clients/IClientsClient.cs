using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Models;

namespace Auth0.ManagementApi.Client.Clients
{
    /// <summary>
    /// Contains all the methods to call the /clients endpoints.
    /// </summary>
    public interface IClientsClient
    {
        /// <summary>
        ///     Creates a new client application.
        /// </summary>
        /// <param name="request">The request containing the properties of the new client.</param>
        /// <returns></returns>
        Task<Core.Models.Client> Create(ClientCreateRequest request);

        /// <summary>
        ///     Deletes a client and all its related assets (like rules, connections, etc) given its id.
        /// </summary>
        /// <param name="id">The id of the client to delete.</param>
        /// <returns></returns>
        Task Delete(string id);

        /// <summary>
        ///     Retrieves a client by its id.
        /// </summary>
        /// <param name="id">The id of the client to retrieve</param>
        /// <param name="fields">
        ///     A comma separated list of fields to include or exclude (depending on includeFields) from the
        ///     result, empty to retrieve all fields
        /// </param>
        /// <param name="includeFields">
        ///     true if the fields specified are to be included in the result, false otherwise (defaults to
        ///     true)
        /// </param>
        /// <returns></returns>
        Task<Core.Models.Client> Get(string id, string fields = null, bool includeFields = true);

        /// <summary>
        ///     Retrieves a list of all client applications. Accepts a list of fields to include or exclude.
        /// </summary>
        /// <param name="fields">
        ///     A comma separated list of fields to include or exclude (depending on includeFields) from the
        ///     result, empty to retrieve all fields
        /// </param>
        /// <param name="includeFields">
        ///     true if the fields specified are to be included in the result, false otherwise (defaults to
        ///     true)
        /// </param>
        /// <returns></returns>
        Task<IList<Core.Models.Client>> GetAll(string fields = null, bool includeFields = true);

        /// <summary>
        ///     Updates a client application.
        /// </summary>
        /// <param name="id">The id of the client you want to update.</param>
        /// <param name="request">The request containing the properties of the client you want to update.</param>
        /// <returns></returns>
        Task<Core.Models.Client> Update(string id, ClientUpdateRequest request);
    }
}