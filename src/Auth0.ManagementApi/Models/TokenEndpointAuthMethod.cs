using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Authentication method for the token endpoint
    /// </summary>
    public enum TokenEndpointAuthMethod
    {
        /// <summary>
        /// Public client without a client secret)
        /// </summary>
        [EnumMember(Value = "none")]
        None,

        /// <summary>
        /// Client uses HTTP POST parameters
        /// </summary>
        [EnumMember(Value = "client_secret_post")]
        ClientSecretPost,

        /// <summary>
        /// Client uses HTTP Basic
        /// </summary>
        [EnumMember(Value = "client_secret_basic")]
        ClientSecretBasic
    }
}