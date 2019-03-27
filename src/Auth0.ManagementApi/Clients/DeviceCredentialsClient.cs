using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <inheritdoc />
    public class DeviceCredentialsClient : ClientBase, IDeviceCredentialsClient
    {
        /// <summary>
        /// Creates a new instance of <see cref="DeviceCredentialsClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public DeviceCredentialsClient(ApiConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public Task<IList<DeviceCredential>> GetAllAsync(string fields = null, bool includeFields = true, string userId = null, string clientId = null, string type = null)
        {
            return Connection.GetAsync<IList<DeviceCredential>>("device-credentials", null,
                new Dictionary<string, string>
                {
                    {"fields", fields},
                    {"include_fields", includeFields.ToString().ToLower()},
                    {"user_id", userId},
                    {"client_id", clientId},
                    {"type", type}
                }, null, null);
        }

        /// <inheritdoc />
        public Task<DeviceCredential> CreateAsync(DeviceCredentialCreateRequest request)
        {
            return Connection.PostAsync<DeviceCredential>("device-credentials", request, null, null, null, null, null);
        }

        /// <inheritdoc />
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>("device-credentials/{id}", 
                new Dictionary<string, string>
                {
                    {"id", id}
                }, null);
        }
    }
}