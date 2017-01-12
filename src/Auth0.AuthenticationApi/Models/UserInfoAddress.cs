using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a physical mailing address of an user.
    /// </summary>
    public class UserInfoAddress
    {
        /// <summary>
        /// Gets or sets the full mailing address, formatted for display or use on a mailing label.
        /// </summary>
        /// <remarks>
        /// This field MAY contain multiple lines, separated by newlines.
        /// Newlines can be represented either as a carriage return/line feed pair ("\r\n") or as a single line feed character ("\n").
        /// </remarks>
        [JsonProperty("formatted")]
        public string Formatted { get; set; }

        /// <summary>
        /// Gets or sets the full street address component, which MAY include house number, 
        /// street name, Post Office Box, and multi-line extended street address information.
        /// </summary>
        /// <remarks>
        /// This field MAY contain multiple lines, separated by newlines. Newlines can be represented 
        /// either as a carriage return/line feed pair ("\r\n") or as a single line feed character ("\n").
        /// </remarks>
        [JsonProperty("street_address")]
        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the city or locality component of the address.
        /// </summary>
        [JsonProperty("locality")]
        public string Locality { get; set; }

        /// <summary>
        /// Gets or sets the state, province, prefecture, or region component of the address.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets the zip code or postal code component of the address.
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the country component of the address.
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }
    }
}
