using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class SigningKey
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cert")]
        public string Cert { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pkcs7")]
        public string Pkcs7 { get; set; }
    }
}