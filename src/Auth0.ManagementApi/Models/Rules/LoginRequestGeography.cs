using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Rules
{

    /// <summary>
    /// 
    /// </summary>
    [JsonObject]
    public class LoginRequestGeography
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("continent_code")]
        public string ContinentCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("country_code3")]
        public string CountryCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("country_name")]
        public string CountryName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("country_code")]
        public string ShortCountryCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

    }

}