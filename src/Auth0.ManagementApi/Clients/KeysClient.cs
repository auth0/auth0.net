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
    /// Contains methods to access the /keys endpoints.
    /// </summary>
    public class KeysClient : BaseClient
    {
        readonly JsonConverter[] keysConverters = new JsonConverter[] { new PagedListConverter<SigningKey>("keys") };
        //readonly JsonConverter[] assignedUsersConverters = new JsonConverter[] { new PagedListConverter<AssignedUser>("users") };
        //readonly JsonConverter[] assignedUsersCheckpointConverters = new JsonConverter[] { new CheckpointPagedListConverter<AssignedUser>("users") };
        //readonly JsonConverter[] permissionsConverters = new JsonConverter[] { new PagedListConverter<Permission>("permissions") };

        /// <summary>
        /// Initializes a new instance of the <see cref="KeysClient"/> class.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public KeysClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Get all Application Signing Keys
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>All available signing keys <see cref="SigningKey" />.</returns>
        public Task<IList<SigningKey>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<IList<SigningKey>>(BuildUri("keys/signing"), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get an Application Signing Key by its key ID.
        /// </summary>
        /// <param name="kid">The ID of the key to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="SigningKey"/> that was requested.</returns>
        public Task<SigningKey> GetAsync(string kid, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<SigningKey>(BuildUri($"keys/signing/{EncodePath(kid)}"), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Rotate the Application Signing Key
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The next <see cref="SigningKey" /> cert and kid.</returns>
        public Task<RotateSigningKeyResponse> RotateSigningKeyAsync( CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<RotateSigningKeyResponse>(HttpMethod.Post, BuildUri("keys/signing/rotate"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Revoke an Application Signing Key by its key ID.
        /// </summary>
        /// <param name="kid">The ID of the key to revoke.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="SigningKey"/> that was requested.</returns>
        public Task<RevokeSigningKeyResponse> RevokeSigningKeyAsync(string kid, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<RevokeSigningKeyResponse>(HttpMethod.Put, BuildUri($"keys/signing/{EncodePath(kid)}/revoke"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}
