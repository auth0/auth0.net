using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Auth0.Core;
using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{

    /// <summary>
    /// Contains all the methods to call the /blacklists/tokens endpoints.
    /// </summary>
    public interface IBlacklistedTokensClient
    {
        /// <summary>
        /// Blacklists a JWY token.
        /// </summary>
        /// <param name="request">The <see cref="BlacklistedTokenCreateRequest"/> containing the information of the token to blacklist.</param>
        /// <returns></returns>
        Task CreateAsync(BlacklistedTokenCreateRequest request);

        /// <summary>
        /// Gets all the blacklisted claims.
        /// </summary>
        /// <param name="aud">The aud claim for which you want to get blacklisted tokens. This is your API Key.</param>
        /// <returns>A list of <see cref="BlacklistedToken"/> objects.</returns>
        Task<IList<BlacklistedToken>> GetAllAsync(string aud);

        #region Obsolete Methods
#pragma warning disable 1591

        [Obsolete("Use CreateAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task Create(BlacklistedTokenCreateRequest request);

        [Obsolete("Use GetAllAsync instead")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Task<IList<BlacklistedToken>> GetAll(string aud);

#pragma warning restore 1591
        #endregion
    }

}