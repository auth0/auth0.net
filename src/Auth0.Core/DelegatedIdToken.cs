using Newtonsoft.Json;

namespace Auth0.Core
{

    /// <summary>
    /// 
    /// </summary>
    public class DelegatedIdToken : DelegatedTokenBase
    {

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id_token")]
        public string IdToken { get; set; }

        #endregion

        #region Constructors



        #endregion

    }

}
