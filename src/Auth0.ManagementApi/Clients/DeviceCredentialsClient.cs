using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /device-credentials endpoints.
    /// </summary>
    public class DeviceCredentialsClient : ClientBase, IDeviceCredentialsClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceCredentialsClient"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public DeviceCredentialsClient(ApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Gets a list of all the device credentials.
        /// </summary>
        /// <param name="fields">A comma separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields.</param>
        /// <param name="includeFields">True if the fields specified are to be excluded from the result, false otherwise (defaults to true).</param>
        /// <param name="userId">The user id of the devices to retrieve</param>
        /// <param name="clientId">The client id of the devices to retrieve.</param>
        /// <param name="type">The type of credentials</param>
        /// <returns>A list of <see cref="DeviceCredential" /> which conforms to the criteria specified.</returns>
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

        /// <summary>
        /// Creates a new device credential.
        /// </summary>
        /// <param name="request">The request containing the details of the device credential to create.</param>
        /// <returns>Tnew newly created <see cref="DeviceCredential" /></returns>
        public Task<DeviceCredential> CreateAsync(DeviceCredentialCreateRequest request)
        {
            return Connection.PostAsync<DeviceCredential>("device-credentials", request, null, null, null, null, null);
        }

        /// <summary>
        /// Deletes a device credential.
        /// </summary>
        /// <param name="id">The id of the device credential to delete</param>
        /// <returns>Task.</returns>
        public Task DeleteAsync(string id)
        {
            return Connection.DeleteAsync<object>("device-credentials/{id}", new Dictionary<string, string>
            {
                {"id", id}
            });
        }

        #region Obsolete Methods
#pragma warning disable 1591

        [Obsolete("Use CreateAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task<DeviceCredential> Create(DeviceCredentialCreateRequest request)
        {
            return CreateAsync(request);
        }

        [Obsolete("Use DeleteAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task Delete(string id)
        {
            return DeleteAsync(id);
        }

        [Obsolete("Use GetAllAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task<IList<DeviceCredential>> GetAll(string fields = null, bool includeFields = true, string userId = null, string clientId = null, string type = null)
        {
            return GetAllAsync(fields, includeFields, userId, clientId, type);
        }

#pragma warning restore 1591
        #endregion
    }
}