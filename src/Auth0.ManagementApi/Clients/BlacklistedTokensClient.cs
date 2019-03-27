using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Http;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <inheritdoc />
    public class BlacklistedTokensClient : ClientBase, IBlacklistedTokensClient
    {
        /// <summary>
        /// Creates a new instance of <see cref="BlacklistedTokensClient"/>.
        /// </summary>
        /// <param name="connection">The <see cref="IApiConnection" /> which is used to communicate with the API.</param>
        public BlacklistedTokensClient(IApiConnection connection)
            : base(connection)
        {
        }

        /// <inheritdoc />
        public Task<IList<BlacklistedToken>> GetAllAsync(string aud)
        {
            return Connection.GetAsync<IList<BlacklistedToken>>("blacklists/tokens", null,
                new Dictionary<string, string>
                {
                    {"aud", aud}
                }, null, null);
        }

        /// <inheritdoc />
        public Task CreateAsync(BlacklistedTokenCreateRequest request)
        {
            return Connection.PostAsync<Client>("blacklists/tokens", request, null, null, null, null, null);
        }
    }
}