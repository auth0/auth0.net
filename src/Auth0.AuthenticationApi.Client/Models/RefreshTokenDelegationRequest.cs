using Newtonsoft.Json;

namespace Auth0.Core
{

    /// <summary>
    /// 
    /// </summary>
    public class RefreshTokenDelegationRequest : DelegationRequestBase
    {

        #region Properties

        /// <summary>
        /// The current RefreshToken to update.
        /// </summary>
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceClientId"></param>
        /// <param name="targetClientId"></param>
        /// <param name="refreshToken"></param>
        public RefreshTokenDelegationRequest(string sourceClientId, string targetClientId, string refreshToken) : base(sourceClientId, targetClientId)
        {
            RefreshToken = refreshToken;
        }

        #endregion

    }
}
