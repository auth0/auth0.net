using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Collections;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
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
        Task<Client> CreateAsync(ClientCreateRequest request);

        /// <summary>
        ///     Deletes a client and all its related assets (like rules, connections, etc) given its id.
        /// </summary>
        /// <param name="id">The id of the client to delete.</param>
        /// <returns></returns>
        Task DeleteAsync(string id);

        /// <summary>
        /// Retrieves a list of all client applications.
        /// </summary>
        /// <param name="page">The page number. Zero based.</param>
        /// <param name="perPage">The amount of entries per page. Default: no paging is used, all connections are returned.</param>
        /// <param name="includeTotals">True if a query summary must be included in the result, false otherwise. Default false.</param>
        /// <param name="fields">A comma separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields.</param>
        /// <param name="includeFields">true if the fields specified are to be included in the result, false otherwise (defaults to true).</param>
        /// <param name="isGlobal">Filter on the global client parameter.</param>
        /// <param name="isFirstParty">Filter on whether or not a client is a first party client.</param>
        /// <param name="appType">List of application types used to filter the returned clients</param>
        /// <returns></returns>
        Task<IPagedList<Client>> GetAllAsync(int? page = null, int? perPage = null, bool? includeTotals = null, 
            string fields = null, bool? includeFields = null, bool? isGlobal = null, bool? isFirstParty = null, ClientApplicationType[] appType = null);

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
        [Obsolete("Use the paged method overload instead")]
        Task<IList<Client>> GetAllAsync(string fields = null, bool includeFields = true);

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
        Task<Client> GetAsync(string id, string fields = null, bool includeFields = true);

        /// <summary>
        /// Rotate a client secret. The generated secret is NOT base64 encoded.
        /// </summary>
        /// <param name="id">The id of the client which secret needs to be rotated</param>
        /// <returns></returns>
        Task<Client> RotateClientSecret(string id);

        /// <summary>
        ///     Updates a client application.
        /// </summary>
        /// <param name="id">The id of the client you want to update.</param>
        /// <param name="request">The request containing the properties of the client you want to update.</param>
        /// <returns></returns>
        Task<Client> UpdateAsync(string id, ClientUpdateRequest request);
    }
}