using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /device-credentials endpoints.
    /// </summary>
    public class DeviceCredentialsClient : ClientBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="DeviceCredentialsClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public DeviceCredentialsClient(IApiConnection connection)
            : base(connection)
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
        /// <returns>A list of <see cref="DeviceCredential"/> which conforms to the criteria specified.</returns>
        public Task<IList<DeviceCredential>> GetAllAsync(string fields = null, bool includeFields = true, string userId = null, string clientId = null, string type = null)
        {
            return Connection.RunAsync<IList<DeviceCredential>>(HttpMethod.Get, "device-credentials", queryStrings:
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()},
                    {"user_id", userId},
                    {"client_id", clientId},
                    {"type", type}
                });
        }

        /// <summary>
        /// Creates a new device credential.
        /// </summary>
        /// <param name="request">The request containing the details of the device credential to create.</param>
        /// <returns>The newly created <see cref="DeviceCredential"/>.</returns>
        public Task<DeviceCredential> CreateAsync(DeviceCredentialCreateRequest request)
        {
            return Connection.RunAsync<DeviceCredential>(HttpMethod.Post, "device-credentials", request);
        }

        /// <summary>
        /// Deletes a device credential.
        /// </summary>
        /// <param name="id">The id of the device credential to delete.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id)
        {
            return Connection.RunAsync<object>(HttpMethod.Delete, $"device-credentials/{id}");
        }
    }
}