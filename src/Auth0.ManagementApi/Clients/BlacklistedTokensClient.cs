using Auth0.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /blacklists/tokens endpoints.
    /// </summary>
    public class BlacklistedTokensClient : BaseClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BlacklistedTokensClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders"><see cref="IDictionary{string, string}"/> containing default headers included with every request this client makes.</param>
        public BlacklistedTokensClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Gets all the blacklisted claims.
        /// </summary>
        /// <param name="aud">The JWT's aud claim. The client_id of the client for which it was issued.</param>
        /// <returns>A list of <see cref="BlacklistedToken"/> objects.</returns>
        public Task<IList<BlacklistedToken>> GetAllAsync(string aud)
        {
            return Connection.GetAsync<IList<BlacklistedToken>>(BuildUri("blacklists/tokens", new Dictionary<string, string> {
                {  "aud", aud }
            }), DefaultHeaders);
        }

        /// <summary>
        /// Blacklists a JWT token.
        /// </summary>
        /// <param name="request">The <see cref="BlacklistedTokenCreateRequest"/> containing the information of the token to blacklist.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous create operation.</returns>
        public Task CreateAsync(BlacklistedTokenCreateRequest request)
        {
            return Connection.SendAsync<Client>(HttpMethod.Post, BuildUri("blacklists/tokens"), request, DefaultHeaders);
        }
    }
}