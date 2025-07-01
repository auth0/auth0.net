using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.Models.Flow;

public class FlowExecutionGetRequest
{
    public string FlowId { get; set; }
        
    public string ExecutionId { get; set; }
        
    /// <summary>
    /// Hydration param
    /// Possible values: [debug]
    /// </summary>
    public Hydrate[] Hydrate { get; set; }
        
    public PaginationInfo PaginationInfo { get; set; }
        
    public CheckpointPaginationInfo CheckpointPaginationInfo { get; set; }
}