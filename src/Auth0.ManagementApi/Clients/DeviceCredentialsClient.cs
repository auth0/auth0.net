using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /device-credentials endpoints.
    /// </summary>
    public class DeviceCredentialsClient : BaseClient, IDeviceCredentialsClient
    {

        readonly JsonConverter[] converters = new JsonConverter[] { new PagedListConverter<DeviceCredential>("device_credentials") };

        /// <summary>
        /// Initializes a new instance of <see cref="DeviceCredentialsClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public DeviceCredentialsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Gets a list of all the device credentials.
        /// </summary>
        /// <param name="fields">A comma separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields.</param>
        /// <param name="includeFields">True if the fields specified are to be excluded from the result, false otherwise (defaults to true).</param>
        /// <param name="userId">The user id of the devices to retrieve.</param>
        /// <param name="clientId">The client id of the devices to retrieve.</param>
        /// <param name="type">The type of credentials.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A list of <see cref="DeviceCredential"/> which conforms to the criteria specified.</returns>
        [Obsolete("Getting a list of device credentials without pagination is not recommended. Please use the overload that accepts pagination information.")]
        public Task<IList<DeviceCredential>> GetAllAsync(string fields = null, bool includeFields = true, string userId = null, string clientId = null, string type = null, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<IList<DeviceCredential>>(BuildUri("device-credentials",
                    new Dictionary<string, string>
                    {
                        { "fields", fields },
                        { "include_fields", includeFields.ToString().ToLower() },
                        { "user_id", userId },
                        { "client_id", clientId },
                        { "type", type }
                    }),
                DefaultHeaders,
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Gets a list of all the device credentials.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying device credentials.</param>
        /// <param name="pagination">Specifies <see cref="PaginationInfo"/> to use in requesting paged results.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A list of <see cref="DeviceCredential"/> which conforms to the criteria specified.</returns>
        public Task<IPagedList<DeviceCredential>> GetAllAsync(GetDeviceCredentialsRequest request, PaginationInfo pagination = null, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var queryStrings = new Dictionary<string, string>
                {
                    {"fields", request.Fields},
                    {"include_fields", request.IncludeFields.ToString().ToLower()},
                    {"user_id", request.UserId},
                    {"client_id", request.ClientId},
                    {"type", request.Type},
                };

            if (pagination != null)
            {
                queryStrings["page"] = pagination.PageNo.ToString();
                queryStrings["per_page"] = pagination.PerPage.ToString();
                queryStrings["include_totals"] = pagination.IncludeTotals.ToString().ToLower();
            }

            return Connection.GetAsync<IPagedList<DeviceCredential>>(BuildUri("device-credentials", queryStrings), DefaultHeaders, converters, cancellationToken);
        }


        /// <summary>
        /// Creates a new device credential.
        /// </summary>
        /// <param name="request">The request containing the details of the device credential to create.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The newly created <see cref="DeviceCredential"/>.</returns>
        public Task<DeviceCredential> CreateAsync(DeviceCredentialCreateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<DeviceCredential>(HttpMethod.Post, BuildUri("device-credentials"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Deletes a device credential.
        /// </summary>
        /// <param name="id">The id of the device credential to delete.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"device-credentials/{EncodePath(id)}"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}
