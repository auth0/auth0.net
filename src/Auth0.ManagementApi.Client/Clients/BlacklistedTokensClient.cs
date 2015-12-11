using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.Core.Http;
using Auth0.ManagementApi.Client.Models;

namespace Auth0.ManagementApi.Client.Clients
{
    /// <summary>
    /// Contains all the methods to call the /blacklists/tokens endpoints.
    /// </summary>
    public class BlacklistedTokensClient : ClientBase, IBlacklistedTokensClient
    {
        /// <summary>
        /// Creates a new instance of the ClientBase class.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public BlacklistedTokensClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <summary>
        /// Gets all the blacklisted claims.
        /// </summary>
        /// <param name="aud">The aud claim for which you want to get blacklisted tokens. This is your API Key.</param>
        /// <returns>A list of <see cref="BlacklistedToken" /> objects.</returns>
        public Task<IList<BlacklistedToken>> GetAll(string aud)
        {
            return Connection.GetAsync<IList<BlacklistedToken>>("blacklists/tokens", null,
                new Dictionary<string, string>
                {
                    {"aud", aud}
                }, null);
        }

        /// <summary>
        /// Blacklists a JWY token.
        /// </summary>
        /// <param name="request">The <see cref="BlacklistedTokenCreateRequest" /> containing the information of the token to blacklist.</param>
        /// <returns>Task.</returns>
        public Task Create(BlacklistedTokenCreateRequest request)
        {
            return Connection.PostAsync<Core.Client>("blacklists/tokens", request, null, null, null, null, null);
        }
    }
}