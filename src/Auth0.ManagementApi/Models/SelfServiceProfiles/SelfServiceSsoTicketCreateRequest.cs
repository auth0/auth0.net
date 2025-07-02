using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.SelfServiceProfiles;

public class SelfServiceSsoTicketCreateRequest
{
    /// <summary>
    /// If provided, this will allow editing of the provided connection during the SSO Flow
    /// </summary>
    [JsonProperty("connection_id")]
    public string ConnectionId { get; set; }
        
    /// <inheritdoc cref="SelfServiceSsoConnectionConfig"/>
    [JsonProperty("connection_config")]
    public SelfServiceSsoConnectionConfig ConnectionConfig { get; set; }
        
    /// <summary>
    /// List of client_ids that the connection will be enabled for.
    /// </summary>
    [JsonProperty("enabled_clients")]
    public string[] EnabledClients { get; set; }
        
    /// <inheritdoc cref="EnabledOrganization"/>
    [JsonProperty("enabled_organizations")]
    public IList<EnabledOrganization> EnabledOrganizations { get; set; }
        
    /// <summary>
    /// Number of seconds for which the ticket is valid before expiration.
    /// If unspecified or set to 0, this value defaults to 432000 seconds (5 days).
    /// </summary>
    [JsonProperty("ttl_sec")]
    public int? TtlSec { get; set; }
}