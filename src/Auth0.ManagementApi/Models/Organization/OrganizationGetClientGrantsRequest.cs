using System.Collections.Generic;

namespace Auth0.ManagementApi.Models;

public class OrganizationGetClientGrantsRequest
{
    /// <summary>
    ///  URL Encoded audience of a client grant to filter.
    /// </summary>
    public string Audience { get; set; }

    /// <summary>
    ///  The Id of a client to filter by. 
    /// </summary>
    public string ClientId { get; set; }
        
    /// <summary>
    /// List of GrantIds to filter results on
    /// </summary>
    public IList<string> GrantIds { get; set; }
}