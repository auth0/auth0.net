using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.Models.Flow;

/// <summary>
/// Contains information required for getting <see cref="FlowVaultConnection"/>
/// </summary>
public class FlowVaultConnectionGetRequest
{
    /// <summary>
    /// Flow Vault Connection identifier, to be mentioned when we want to fetch a specific flow vault connection.
    /// </summary>
    public string Id { get; set; }
        
    /// <summary>
    /// <see cref="PaginationInfo"/>
    /// </summary>
    public PaginationInfo PaginationInfo { get; set; }
}