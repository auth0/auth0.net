using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /device-credentials endpoints.
    /// </summary>
    public interface IDeviceCredentialsClient
    {
        /// <summary>
        /// Creates a new device credential.
        /// </summary>
        /// <param name="request">The request containing the details of the device credential to create.</param>
        /// <returns>Tnew newly created <see cref="DeviceCredential"/></returns>
        Task<DeviceCredential> CreateAsync(DeviceCredentialCreateRequest request);

        /// <summary>
        /// Deletes a device credential.
        /// </summary>
        /// <param name="id">The id of the device credential to delete</param>
        Task DeleteAsync(string id);

        /// <summary>
        /// Gets a list of all the device credentials.
        /// </summary>
        /// <param name="fields">A comma separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields.</param>
        /// <param name="includeFields">True if the fields specified are to be excluded from the result, false otherwise (defaults to true).</param>
        /// <param name="userId">The user id of the devices to retrieve</param>
        /// <param name="clientId">The client id of the devices to retrieve.</param>
        /// <param name="type">The type of credentials</param>
        /// <returns>A list of <see cref="DeviceCredential"/> which conforms to the criteria specified.</returns>
        Task<IList<DeviceCredential>> GetAllAsync(string fields = null, bool includeFields = true, string userId = null, string clientId = null, string type = null);

        #region Obsolete Methods
#pragma warning disable 1591

        [Obsolete("Use CreateAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<DeviceCredential> Create(DeviceCredentialCreateRequest request);

        [Obsolete("Use DeleteAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task Delete(string id);

        [Obsolete("Use GetAllAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<IList<DeviceCredential>> GetAll(string fields = null, bool includeFields = true, string userId = null, string clientId = null, string type = null);

#pragma warning restore 1591
        #endregion
    }
}