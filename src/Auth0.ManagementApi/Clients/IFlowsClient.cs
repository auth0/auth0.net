using System.Threading;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models.Flow;
using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.Clients
{
    public interface IFlowsClient
    {
        /// <summary>
        /// Get <see cref="Flow"/>s
        /// </summary>
        /// <param name="request"><see cref="FlowGetRequest"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="IPagedList{T}"/> of <see cref="Flow"/></returns>
        Task<IPagedList<Flow>> GetAllAsync(FlowGetRequest request, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Create a <see cref="Flow"/>.
        /// </summary>
        /// <param name="request"><see cref="FlowCreateRequest"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>A <see cref="Flow"/></returns>
        Task<Flow> CreateAsync(FlowCreateRequest request, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Get a <see cref="Flow"/>.
        /// </summary>
        /// <param name="request"><see cref="FlowGetRequest"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>A <see cref="Flow"/></returns>
        Task<Flow> GetAsync(FlowGetRequest request, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Update a <see cref="Flow"/>
        /// </summary>
        /// <param name="id">Identifier of the flow to be updated</param>
        /// <param name="request"><see cref="FlowUpdateRequest"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>Updated <see cref="Flow"/></returns>
        Task<Flow> UpdateAsync(string id, FlowUpdateRequest request, CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Delete a <see cref="Flow"/>
        /// </summary>
        /// <param name="id">Identifier of the flow to delete</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        Task DeleteAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get <see cref="FlowVaultConnection"/> list
        /// </summary>
        /// <param name="request"><see cref="FlowVaultConnectionGetRequest"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="IPagedList{T}"/> of <see cref="FlowVaultConnection"/></returns>
        Task<IPagedList<FlowVaultConnection>> GetAllFlowVaultConnectionsAsync(
            FlowVaultConnectionGetRequest request,
            CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Create a Flows Vault connection
        /// </summary>
        /// <param name="request"><see cref="FlowVaultConnectionCreateRequest"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>A <see cref="FlowVaultConnection"/></returns>
        Task<FlowVaultConnection> CreateVaultConnectionAsync(
            FlowVaultConnectionCreateRequest request,
            CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Get a <see cref="FlowVaultConnection"/>.
        /// </summary>
        /// <param name="request"><see cref="FlowVaultConnectionGetRequest"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>A <see cref="FlowVaultConnection"/></returns>
        Task<FlowVaultConnection> GetFlowVaultConnectionAsync(
            FlowVaultConnectionGetRequest request,
            CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Update a <see cref="Flow"/>
        /// </summary>
        /// <param name="id">Identifier of the flow to be updated</param>
        /// <param name="request"><see cref="FlowVaultConnectionUpdateRequest"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns>Updated <see cref="FlowVaultConnection"/></returns>
        Task<FlowVaultConnection> UpdateFlowVaultConnectionAsync(
            string id,
            FlowVaultConnectionUpdateRequest request,
            CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Delete a <see cref="FlowVaultConnection"/>
        /// </summary>
        /// <param name="id">Identifier of the flow to delete</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        Task DeleteFlowVaultConnectionAsync(string id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get <see cref="Flow"/> executions.
        /// </summary>
        /// <param name="flowId">Flow identifier for which we need to fetch the executions</param>
        /// <param name="paginationInfo"><see cref="PaginationInfo"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="IPagedList{T}"/> list of <see cref="FlowExecution"/></returns>
        Task<IPagedList<FlowExecution>> GetAllFlowExecutionsAsync(
            string flowId,
            PaginationInfo paginationInfo, 
            CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Get <see cref="Flow"/> executions.
        /// </summary>
        /// <param name="flowId">Flow identifier for which we need to fetch the executions</param>
        /// <param name="paginationInfo"><see cref="CheckpointPaginationInfo"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="ICheckpointPagedList{T}"/>"/> list of <see cref="FlowExecution"/></returns>
        Task<ICheckpointPagedList<FlowExecution>> GetAllFlowExecutionsAsync(
            string flowId,
            CheckpointPaginationInfo paginationInfo, 
            CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Get a <see cref="FlowExecution"/>.
        /// </summary>
        /// <param name="flowId">Flow identifier for which we need to fetch the execution</param>
        /// <param name="executionId">Flow execution ID</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="FlowExecution"/></returns>
        Task<FlowExecution> GetFlowExecutionAsync(
            string flowId,
            string executionId,
            CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Delete a <see cref="FlowExecution"/>
        /// </summary>
        /// <param name="flowId">Flow identifier for which we need to fetch the execution</param>
        /// <param name="executionId">Flow execution ID</param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        Task DeleteFlowExecutionAsync(string flowId, string executionId, CancellationToken cancellationToken = default);
    }
}