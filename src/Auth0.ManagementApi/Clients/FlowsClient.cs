using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Auth0.ManagementApi.Models.Flow;
using Auth0.ManagementApi.Paging;

namespace Auth0.ManagementApi.Clients
{
    public class FlowsClient : BaseClient, IFlowsClient
    {
        private readonly JsonConverter[] _flowsConverters = { new PagedListConverter<Flow>("flows") };
        private readonly JsonConverter[] _flowVaultConnectionConverters = 
            { new PagedListConverter<FlowVaultConnection>("connections") };
        private readonly JsonConverter[] _paginationFlowExecutionConverters = { new PagedListConverter<FlowExecution>("executions") };
        private readonly JsonConverter[] _checkpointPaginationFlowExecutionConverters = { new CheckpointPagedListConverter<FlowExecution>("executions") };
        
        /// <summary>
        /// Initializes a new instance of <see cref="FlowsClient"/>
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/></param>
        /// <param name="baseUri"><see cref="Uri"/></param>
        /// <param name="defaultHeaders">Default headers</param>
        public FlowsClient(
            IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders) : base(
            connection, baseUri, defaultHeaders)
        {
        }

        /// <inheritdoc />
        public Task<IPagedList<Flow>> GetAllAsync(FlowGetRequest request, CancellationToken cancellationToken = default)
        {
            request.ThrowIfNull();

            var queryStrings = new Dictionary<string, string>();

            if (request.Hydrate != null && request.Hydrate.Any())
            {
                var hydrateValues = string.Join(",",  request.Hydrate.Select( x => x.ToString().ToLower()));
                queryStrings["hydrate"] = hydrateValues;
            }

            if (request.PaginationInfo != null)
            {
                queryStrings["page"] = request.PaginationInfo.PageNo.ToString();
                queryStrings["per_page"] = request.PaginationInfo.PerPage.ToString();
                queryStrings["include_totals"] = request.PaginationInfo.IncludeTotals.ToString().ToLower();
            }

            return Connection.GetAsync<IPagedList<Flow>>(
                BuildUri("flows", queryStrings),
                DefaultHeaders,
                _flowsConverters,
                cancellationToken);
        }

        /// <inheritdoc />
        public Task<Flow> CreateAsync(FlowCreateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Flow>(
                HttpMethod.Post,
                BuildUri("flows"),
                request,
                DefaultHeaders,
                cancellationToken: cancellationToken);
        }
        
        /// <inheritdoc />
        public Task<Flow> GetAsync(FlowGetRequest request, CancellationToken cancellationToken = default)
        {
            request.ThrowIfNull();
            request.Id.ThrowIfNull();

            var queryStrings = new Dictionary<string, string>();

            if (request.Hydrate != null && request.Hydrate.Any())
            {
                var hydrateValues = string.Join(",",  request.Hydrate.Select( x => x.ToString().ToLower()));
                queryStrings["hydrate"] = hydrateValues;
            }

            return Connection.GetAsync<Flow>(
                BuildUri($"flows/{EncodePath(request.Id)}", queryStrings),
                DefaultHeaders,
                null,
                cancellationToken);
        }

        /// <inheritdoc />
        public Task<Flow> UpdateAsync(
            string id, FlowUpdateRequest request, CancellationToken cancellationToken = default)
        {
            id.ThrowIfNull();
            return Connection.SendAsync<Flow>(
                new HttpMethod("PATCH"),
                BuildUri($"flows/{EncodePath(id)}"),
                request, 
                DefaultHeaders, 
                cancellationToken: cancellationToken);
        }

        /// <inheritdoc />
        public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            id.ThrowIfNull();
            return Connection.SendAsync<object>(
                HttpMethod.Delete,
                BuildUri($"flows/{EncodePath(id)}"),
                null,
                DefaultHeaders, 
                cancellationToken: cancellationToken);
        }

        /// <inheritdoc />
        public Task<IPagedList<FlowVaultConnection>> GetAllFlowVaultConnectionsAsync(
            FlowVaultConnectionGetRequest request, CancellationToken cancellationToken = default)
        {
            request.ThrowIfNull();

            var queryStrings = new Dictionary<string, string>();
            
            if (request.PaginationInfo != null)
            {
                queryStrings["page"] = request.PaginationInfo.PageNo.ToString();
                queryStrings["per_page"] = request.PaginationInfo.PerPage.ToString();
                queryStrings["include_totals"] = request.PaginationInfo.IncludeTotals.ToString().ToLower();
            }

            return Connection.GetAsync<IPagedList<FlowVaultConnection>>(
                BuildUri("flows/vault/connections", queryStrings),
                DefaultHeaders,
                _flowVaultConnectionConverters,
                cancellationToken);        
        }

        /// <inheritdoc />
        public Task<FlowVaultConnection> CreateVaultConnectionAsync(
            FlowVaultConnectionCreateRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<FlowVaultConnection>(
                HttpMethod.Post,
                BuildUri("flows/vault/connections"),
                request,
                DefaultHeaders,
                cancellationToken: cancellationToken);
        }

        /// <inheritdoc />
        public Task<FlowVaultConnection> GetFlowVaultConnectionAsync(
            FlowVaultConnectionGetRequest request, CancellationToken cancellationToken = default)
        {
            request.ThrowIfNull();
            request.Id.ThrowIfNull();

            return Connection.GetAsync<FlowVaultConnection>(
                BuildUri($"flows/vault/connections/{EncodePath(request.Id)}"),
                DefaultHeaders,
                null,
                cancellationToken);
        }

        /// <inheritdoc />
        public Task<FlowVaultConnection> UpdateFlowVaultConnectionAsync(
            string id,
            FlowVaultConnectionUpdateRequest request,
            CancellationToken cancellationToken = default)
        {
            id.ThrowIfNull();

            return Connection.SendAsync<FlowVaultConnection>(
                new HttpMethod("PATCH"),
                BuildUri($"flows/vault/connections/{EncodePath(id)}"),
                request,
                DefaultHeaders,
                cancellationToken: cancellationToken);
        }
        
        /// <inheritdoc />
        public Task DeleteFlowVaultConnectionAsync(string id, CancellationToken cancellationToken = default)
        {
            id.ThrowIfNull();

            return Connection.SendAsync<object>(
                HttpMethod.Delete,
                BuildUri($"flows/vault/connections/{EncodePath(id)}"),
                null,
                DefaultHeaders, 
                cancellationToken: cancellationToken);
        }
        
        /// <inheritdoc />
        public Task<IPagedList<FlowExecution>> GetAllFlowExecutionsAsync(string flowId, PaginationInfo paginationInfo,
            CancellationToken cancellationToken = default)
        {
            flowId.ThrowIfNull();

            var queryStrings = new Dictionary<string, string>();

            if (paginationInfo != null)
            {
                queryStrings["page"] = paginationInfo.PageNo.ToString();
                queryStrings["per_page"] = paginationInfo.PerPage.ToString();
                queryStrings["include_totals"] = paginationInfo.IncludeTotals.ToString().ToLower();
            }

            return Connection.GetAsync<IPagedList<FlowExecution>>(
                BuildUri($"flows/{EncodePath(flowId)}/executions", queryStrings),
                DefaultHeaders,
                _paginationFlowExecutionConverters,
                cancellationToken);
        }

        /// <inheritdoc />
        public Task<ICheckpointPagedList<FlowExecution>> GetAllFlowExecutionsAsync(string flowId,
            CheckpointPaginationInfo paginationInfo,
            CancellationToken cancellationToken = default)
        {
            var queryStrings = new Dictionary<string, string>();
            
            if(paginationInfo != null)
            {
                queryStrings["from"] = paginationInfo.From?.ToString();
                queryStrings["take"] = paginationInfo.Take.ToString();
            };
            return Connection.GetAsync<ICheckpointPagedList<FlowExecution>>(
                BuildUri($"flows/{EncodePath(flowId)}/executions", queryStrings),
                DefaultHeaders,
                _checkpointPaginationFlowExecutionConverters, 
                cancellationToken);
        }

        /// <inheritdoc />
        public Task<FlowExecution> GetFlowExecutionAsync(
            string flowId, string executionId, CancellationToken cancellationToken = default)
        {
            flowId.ThrowIfNull();
            executionId.ThrowIfNull();

            return Connection.GetAsync<FlowExecution>(
                BuildUri($"flows/{EncodePath(flowId)}/executions/{EncodePath(executionId)}"),
                DefaultHeaders,
                null,
                cancellationToken);
        }

        /// <inheritdoc />
        public Task DeleteFlowExecutionAsync(
            string flowId, string executionId, CancellationToken cancellationToken = default)
        {
            flowId.ThrowIfNull();
            executionId.ThrowIfNull();

            return Connection.SendAsync<object>(
                HttpMethod.Delete,
                BuildUri($"flows/{EncodePath(flowId)}/executions/{EncodePath(executionId)}"),
                null,
                DefaultHeaders, 
                cancellationToken: cancellationToken);
        }
    }
}