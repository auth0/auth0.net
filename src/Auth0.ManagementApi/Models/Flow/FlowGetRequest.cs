using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.Models.Flow;

/// <summary>
/// Contains information required for getting a flow
/// </summary>
public class FlowGetRequest
{
    public PaginationInfo PaginationInfo { get; set; }
        
    /// <summary>
    /// Hydration param
    /// Possible values: [form_count]
    /// </summary>
    public Hydrate[] Hydrate { get; set; }
        
    /// <summary>
    /// Flag to filter by sync/async flows
    /// </summary>
    public bool? Synchronous { get; set; }
        
    /// <summary>
    /// Flow identifier
    /// </summary>
    public string Id { get; set; }
}