using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.Core.Models;

namespace Auth0.ManagementApi.Client.Clients
{
    public interface IBlacklistedTokensClient
    {
        /// <summary>
        /// Gets all the blacklisted claims.
        /// </summary>
        /// <param name="aud">The aud claim for which you want to get blacklisted tokens. This is your API Key.</param>
        /// <returns>A list of <see cref="BlacklistedToken"/> objects.</returns>
        Task<IList<BlacklistedToken>> GetAll(string aud);

        /// <summary>
        /// Blacklists a JWY token.
        /// </summary>
        /// <param name="request">The <see cref="BlacklistedTokenCreateRequest"/> containing the information of the token to blacklist.</param>
        /// <returns></returns>
        Task Create(BlacklistedTokenCreateRequest request);
    }
}