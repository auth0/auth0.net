﻿using Auth0.Core.Http;
using Auth0.ManagementApi.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains all the methods to call the /blacklists/tokens endpoints.
    /// </summary>
    public class BlacklistedTokensClient : ClientBase
    {
        /// <summary>
        /// Creates a new instance of <see cref="BlacklistedTokensClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public BlacklistedTokensClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Gets all the blacklisted claims.
        /// </summary>
        /// <param name="aud">The JWT's aud claim. The client_id of the client for which it was issued.</param>
        /// <returns>A list of <see cref="BlacklistedToken"/> objects.</returns>
        public Task<IList<BlacklistedToken>> GetAllAsync(string aud)
        {
            return Connection.GetAsync<IList<BlacklistedToken>>("blacklists/tokens", null,
                new Dictionary<string, string>
                {
                    {"aud", aud}
                }, null, null);
        }

        /// <summary>
        /// Blacklists a JWT token.
        /// </summary>
        /// <param name="request">The <see cref="BlacklistedTokenCreateRequest"/> containing the information of the token to blacklist.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous create operation.</returns>
        public Task CreateAsync(BlacklistedTokenCreateRequest request)
        {
            return Connection.RunAsync<Client>(HttpMethod.Post, "blacklists/tokens", request, null, null, null, null, null);
        }
    }
}