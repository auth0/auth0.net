using Newtonsoft.Json;

namespace Auth0.Core
{

    /// <summary>
    /// 
    /// </summary>
    public abstract class DelegationRequestBase
    {

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("api_type")]
        string ApiType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("client_id")]
        public string SourceClientId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("target")]
        public string TargetClientId { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public DelegationRequestBase()
        {
            GrantType = "urn:ietf:params:oauth:grant-type:jwt-bearer";
            Scope = "openid";
            ApiType = "app";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceClientId"></param>
        /// <param name="targetClientId"></param>
        public DelegationRequestBase(string sourceClientId, string targetClientId) : this()
        {
            SourceClientId = sourceClientId;
            TargetClientId = targetClientId;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceClientId"></param>
        /// <param name="targetClientId"></param>
        /// <param name="idToken"></param>
        /// <param name="apiType"></param>
        public DelegationRequestBase(string sourceClientId, string targetClientId, string apiType) : this(sourceClientId, targetClientId)
        {
            ApiType = apiType;
        }

        #endregion

    }
}
