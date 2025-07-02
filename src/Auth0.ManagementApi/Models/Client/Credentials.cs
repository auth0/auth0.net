using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Credentials for the JAR requests
/// </summary>
public class Credentials
{
    /// <summary>
    /// Credential ID
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }
}