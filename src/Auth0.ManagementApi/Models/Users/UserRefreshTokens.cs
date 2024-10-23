using System.Collections.Generic;
using Auth0.ManagementApi.Models.RefreshTokens;

namespace Auth0.ManagementApi.Models.Users
{
    /// <summary>
    /// User's Refresh Tokens
    /// </summary>
    public class UserRefreshTokens
    {
        /// <summary>
        /// List of <see cref="RefreshTokenInformation"/>
        /// </summary>
        public IList<RefreshTokenInformation> Tokens { get; set; }
        
        /// <summary>
        /// The maximum token ID of the current result set, to be used as the "from" query parameter for the next call. 
        /// </summary>
        public string Next { get; set; }
    }
}