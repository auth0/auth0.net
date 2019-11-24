using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a physical mailing address of an user.
    /// </summary>
    public class UserInfoAddress
    {
        /// <summary>
        /// Full mailing address, formatted for display or use on a mailing label.
        /// </summary>
        /// <remarks>
        /// MAY contain multiple lines, separated by newlines as either CRLF (Windows) `\r\n` or LF (Unix) `\n`.
        /// </remarks>
        [JsonProperty("formatted")]
        public string Formatted { get; set; }

        /// <summary>
        /// Full street address component, which MAY include house number, 
        /// street name, Post Office Box, and multi-line extended street address information.
        /// </summary>
        /// <remarks>
        /// MAY contain multiple lines, separated by newlines as either CRLF (Windows) `\r\n` or LF (Unix) `\n`.
        /// </remarks>
        [JsonProperty("street_address")]
        public string StreetAddress { get; set; }

        /// <summary>
        /// City or locality component of the address.
        /// </summary>
        [JsonProperty("locality")]
        public string Locality { get; set; }

        /// <summary>
        /// State, province, prefecture, or region component of the address.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// Zip or postal code component of the address.
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Country component of the address.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
