namespace Auth0.ManagementApi.Models.RefreshTokens;

/// <summary>
/// A list of the resource server IDs associated to this refresh-token and their granted scopes
/// </summary>
public class ResourceServer
{
    /// <summary>
    /// Resource server ID
    /// </summary>
    public string Audience { get; set; }
        
    /// <summary>
    /// List of scopes for the refresh token 
    /// </summary>
    public string Scopes { get; set; }
}