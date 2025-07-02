using Newtonsoft.Json;
using System.Collections.Generic;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Requests structure for creating a new organization.
/// </summary>
public class OrganizationCreateRequest : OrganizationBase
{
    /// <summary>
    /// Support enable connections in organization 
    /// </summary>
    [JsonProperty("enabled_connections")]
    public IList<OrganizationConnectionCreateRequest> EnabledConnections { get; set; }
}