using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.RefreshTokens;

/// <summary>
/// Device used while issuing/exchanging the refresh token/Session
/// </summary>
public class Device
{
    /// <summary>
    /// First IP address associated with the refresh token/Session
    /// </summary>
    [JsonProperty("initial_ip")]
    public string InitialIp { get; set; }
        
    /// <summary>
    /// First autonomous system number associated with the refresh token/Session
    /// </summary>
    [JsonProperty("initial_asn")]
    public string InitialAsn { get; set; }
        
    /// <summary>
    /// First user agent associated with the refresh token/Session
    /// </summary>
    [JsonProperty("initial_user_agent")]
    public string InitialUserAgent { get; set; }
        
    /// <summary>
    /// Last IP address associated with the refresh token/Session
    /// </summary>
    [JsonProperty("last_ip")]
    public string LastIp { get; set; }
        
    /// <summary>
    /// Last autonomous system number associated with the refresh token/Session
    /// </summary>
    [JsonProperty("last_asn")]
    public string LastAsn { get; set; }
        
    /// <summary>
    /// Last user agent associated with the refresh token/Session
    /// </summary>
    [JsonProperty("last_user_agent")]
    public string LastUserAgent { get; set; }
}