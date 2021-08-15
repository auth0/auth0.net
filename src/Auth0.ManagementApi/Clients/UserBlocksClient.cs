using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /user-blocks endpoints.
    /// </summary>
    public class UserBlocksClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="UserBlocksClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public UserBlocksClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Get a user's blocks by identifier.
        /// </summary>
        /// <param name="identifier">The identifier of the user. Can be a user's email address, username or phone number.</param>
        /// <param name="token"></param>
        /// <returns>The <see cref="UserBlocks"/> relating to the user requested.</returns>
        public Task<UserBlocks> GetByIdentifierAsync(string identifier, CancellationToken token = default)
        {
            return Connection.GetAsync<UserBlocks>(BuildUri("user-blocks",
                new Dictionary<string, string>
                {
                    {"identifier", identifier}
                }), DefaultHeaders, token: token);
        }

        /// <summary>
        /// Get a user's blocks by user id.
        /// </summary>
        /// <param name="id">The id of the user.</param>
        /// <param name="token"></param>
        /// <returns>The <see cref="UserBlocks"/> relating to the user requested.</returns>
        public Task<UserBlocks> GetByUserIdAsync(string id, CancellationToken token = default)
        {
            return Connection.GetAsync<UserBlocks>(BuildUri($"user-blocks/{EncodePath(id)}"), DefaultHeaders, token: token);
        }

        /// <summary>
        /// Unblock a user by their identifier.
        /// </summary>
        /// <param name="identifier">The identifier of the user to unblock. Can be a user's email address, username or phone number.</param>
        /// <param name="token"></param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous unblock operation.</returns>
        public Task UnblockByIdentifierAsync(string identifier, CancellationToken token = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri("user-blocks",
                new Dictionary<string, string> { { "identifier", identifier } }), null, DefaultHeaders, token: token);
        }

        /// <summary>
        /// Unblock a user by their id.
        /// </summary>
        /// <param name="id">The id of the user to unblock.</param>
        /// <param name="token"></param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous unblock operation.</returns>
        public Task UnblockByUserIdAsync(string id, CancellationToken token = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"user-blocks/{EncodePath(id)}", 
                new Dictionary<string, string> { { "id", id } }), null, DefaultHeaders, token: token);
        }
    }
}
