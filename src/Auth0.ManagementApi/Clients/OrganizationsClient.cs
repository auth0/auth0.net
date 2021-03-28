using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    public class OrganizationsClient : BaseClient
    {
        readonly JsonConverter[] converters = new JsonConverter[] { new PagedListConverter<Organization>("organizations") };

        /// <summary>
        /// Initializes a new instance of <see cref="ClientsClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public OrganizationsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Retrieves a list of all organizations.
        /// </summary>
        /// <param name="pagination">Specifies pagination info to use when requesting paged results.</param>
        /// <returns>An <see cref="IPagedList{Organization}"/> containing the organizations.</returns>
        public Task<IPagedList<Organization>> GetAllAsync(PaginationInfo pagination)
        {
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            var queryStrings = new Dictionary<string, string>
            {
                {"page", pagination.PageNo.ToString()},
                {"per_page", pagination.PerPage.ToString()},
                {"include_totals", pagination.IncludeTotals.ToString().ToLower()},
            };

            return Connection.GetAsync<IPagedList<Organization>>(BuildUri("organizations", queryStrings), DefaultHeaders, converters);
        }

        /// <summary>
        /// Retrieves an organization by its id.
        /// </summary>
        /// <param name="id">The id of the organization to retrieve.</param>
        /// <returns>The <see cref="Organization"/> retrieved.</returns>
        public Task<Organization> GetAsync(string id)
        {
            return Connection.GetAsync<Organization>(BuildUri($"organizations/{EncodePath(id)}"), DefaultHeaders);
        }

        /// <summary>
        /// Creates a new organization.
        /// </summary>
        /// <param name="request">The <see cref="OrganizationCreateRequest"/> containing the properties of the new organization.</param>
        /// <returns>The new <see cref="Organization"/> that has been created.</returns>
        public Task<Organization> CreateAsync(OrganizationCreateRequest request)
        {
            return Connection.SendAsync<Organization>(HttpMethod.Post, BuildUri("organizations"), request, DefaultHeaders);
        }

        /// <summary>
        /// Updates an organization.
        /// </summary>
        /// <param name="id">The id of the organization you want to update.</param>
        /// <param name="request">The <see cref="OrganizationUpdateRequest"/> containing the properties of the organization you want to update.</param>
        /// <returns>The <see cref="Organization"/> that was updated.</returns>
        public Task<Organization> UpdateAsync(string id, OrganizationUpdateRequest request)
        {
            return Connection.SendAsync<Organization>(new HttpMethod("PATCH"), BuildUri($"organizations/{EncodePath(id)}"), request, DefaultHeaders);
        }

        /// <summary>
        /// Deletes an organization.
        /// </summary>
        /// <param name="id">The id of the organization to delete.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"organizations/{EncodePath(id)}"), null, DefaultHeaders);
        }

    }
}
