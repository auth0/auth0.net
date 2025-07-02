using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions;

/// <summary>
/// Denotes the major.minor version of an integration release
/// </summary>
public class ActionSemVer
{
    /// <summary>
    /// Major version of the semver
    /// </summary>
    [JsonProperty("major")]
    public int Major { get; set; }
        
    /// <summary>
    /// Minor version of the semver
    /// </summary>
    [JsonProperty("minor")]
    public int Minor { get; set; }
}