using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models.Keys;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /keys endpoints.
    /// </summary>
    public class KeysClient : BaseClient, IKeysClient
    {
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
        /// <returns>All available signing keys <see cref="Key" />.</returns>
        public Task<IList<Key>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<IList<Key>>(BuildUri("keys/signing"), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get an Application Signing Key by its key ID.
        /// </summary>
        /// <param name="kid">The ID of the key to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="Key"/> that was requested.</returns>
        public Task<Key> GetAsync(string kid, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<Key>(BuildUri($"keys/signing/{EncodePath(kid)}"), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Rotate the Application Signing Key.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The next rotated key's cert and kid.</returns>
        public Task<RotateSigningKeyResponse> RotateSigningKeyAsync( CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<RotateSigningKeyResponse>(HttpMethod.Post, BuildUri("keys/signing/rotate"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Revoke an Application Signing Key by its key ID.
        /// </summary>
        /// <param name="kid">The ID of the key to revoke.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The revoked key's cert and kid.</returns>
        public Task<RevokeSigningKeyResponse> RevokeSigningKeyAsync(string kid, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<RevokeSigningKeyResponse>(HttpMethod.Put, BuildUri($"keys/signing/{EncodePath(kid)}/revoke"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}
