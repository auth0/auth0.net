using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.RefreshTokens;

public class RefreshTokenInformation : SessionsBase
{
    /// <summary>
    /// ID of the client application granted with this refresh token
    /// </summary>
    [JsonProperty("client_id")]
    public string ClientId { get; set; }
        
    /// <summary>
    /// ID of the authenticated session used to obtain this refresh-token
    /// </summary>
    [JsonProperty("session_id")]
    public string SessionId { get; set; }
        
    /// <summary>
    /// True if the token is a rotating refresh token
    /// </summary>
    [JsonProperty("rotating")]
    public bool? Rotating { get; set; }
        
    /// <summary>
    /// <inheritdoc cref="Auth0.ManagementApi.Models.RefreshTokens.ResourceServer"/>
    /// </summary>
    [JsonProperty("resource_servers")]
    public IList<ResourceServer> ResourceServers { get; set; }
        
    /// <summary>
    /// The date and time when the refresh token was last exchanged
    /// </summary>
    [JsonProperty("last_exchanged_at")]
    public DateTime? LastExchangedAt { get; set; }
}