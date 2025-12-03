using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

public class OrganizationMember
{
    /// <summary>
    /// ID of the user.
    /// </summary>
    [JsonProperty("user_id")]
    public string UserId { get; set; }

    /// <summary>
    /// URL to a picture for the user.
    /// </summary>
    [JsonProperty("picture")]
    public string Picture { get; set; }

    /// <summary>
    /// Name of the user.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Email address of the user.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }
        
    /// <summary>
    /// The roles of the user
    /// </summary>
    /// <remarks>
    /// This property is optional and may be null.
    /// It will only be present if OrganizationGetAllMembersRequest.Fields includes "roles" and OrganizationGetAllMembersRequest.IncludeFields is true.
    /// </remarks>
    [JsonProperty("roles")]
    public IList<Role>? Roles { get; set; }
}