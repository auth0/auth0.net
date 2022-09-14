using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;
using Auth0.ManagementApi.Models.Actions;
using Auth0.ManagementApi.Paging;
using Newtonsoft.Json;
using Action = Auth0.ManagementApi.Models.Actions.Action;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /actions endpoints.
    /// </summary>
    public class ActionsClient : BaseClient, IActionsClient
    {
        private const string ActionsBasePath = "actions";
        private const string ActionsPath = "actions";
        private const string TriggersPath = "triggers";
        private const string ExecutionsPath = "executions";
        private const string VersionsPath = "versions";
        private const string BindingsPath = "bindings";
        private const string DeployPath = "deploy";

        private readonly JsonConverter[] _actionsConverters = { new PagedListConverter<Action>("actions") };
        private readonly JsonConverter[] _triggersConverters = { new ListConverter<Trigger>("triggers") };
        private readonly JsonConverter[] _versionsConverters = { new PagedListConverter<ActionVersion>("versions") };
        private readonly JsonConverter[] _triggerBindingsConverters = { new PagedListConverter<TriggerBinding>("bindings") };
        private readonly JsonConverter[] _triggerBindingsListConverters = { new ListConverter<TriggerBinding>("bindings") };

        public ActionsClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders) : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Retrieve all actions.
        /// </summary>
        /// <param name="request">Specifies criteria to use when querying actions.</param>
        /// <param name="pagination">Specifies pagination info to use.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>An <see cref="IPagedList{Action}"/> containing the actions.</returns>
        public Task<IPagedList<Action>> GetAllAsync(GetActionsRequest request, PaginationInfo pagination, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (pagination == null)
                throw new ArgumentNullException(nameof(pagination));

            var queryStrings = new Dictionary<string, string>
            {
                {"triggerId", request.TriggerId},
                {"actionName", request.ActionName},
                {"deployed", request.Deployed?.ToString()},
                {"page", pagination.PageNo.ToString()},
                {"per_page", pagination.PerPage.ToString()},
                // Uncomment below once "include_totals" is supported.
                // {"include_totals", pagination.IncludeTotals.ToString()},
                {"installed", request.Installed?.ToString()},
            };

            return Connection.GetAsync<IPagedList<Action>>(BuildUri($"{ActionsBasePath}/{ActionsPath}", queryStrings), DefaultHeaders, _actionsConverters, cancellationToken);
        }

        /// <summary>
        /// Retrieve an action by its ID.
        /// </summary>
        /// <param name="id">The ID of the action to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The retrieved action.</returns>
        public Task<Action> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<Action>(BuildUri($"{ActionsBasePath}/{ActionsPath}/{EncodePath(id)}"), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Create an action.
        /// </summary>
        /// <remarks>
        /// Once an action is created, it must be deployed, and then bound to a trigger before it will be executed as part of a flow.
        /// </remarks>
        /// <param name="request">Specifies criteria to use when creating an action.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The new <see cref="Action"/> that has been created.</returns>
        public Task<Action> CreateAsync(CreateActionRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Action>(HttpMethod.Post, BuildUri($"{ActionsBasePath}/{ActionsPath}"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Update an existing action.
        /// </summary>
        /// <remarks>
        /// If this action is currently bound to a trigger, updating it will not affect any user flows until the action is deployed.
        /// </remarks>
        /// <param name="id">The id of the action to update.</param>
        /// <param name="request">Specifies criteria to use when updating an action.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The <see cref="Action"/> that was updated.</returns>
        public Task<Action> UpdateAsync(string id, UpdateActionRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<Action>(new HttpMethod("PATCH"), BuildUri($"{ActionsBasePath}/{ActionsPath}/{EncodePath(id)}"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Deletes an action and all of its associated versions.
        /// </summary>
        /// <remarks>
        /// An action must be unbound from all triggers before it can be deleted.
        /// </remarks>
        /// <param name="id">The ID of the action to delete.</param>
        /// <param name="request">Specifies criteria to use when deleting an action.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteAsync(string id, DeleteActionRequest request = null, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(HttpMethod.Delete, BuildUri($"{ActionsBasePath}/{ActionsPath}/{EncodePath(id)}"), request, DefaultHeaders, cancellationToken: cancellationToken);
        }


        /// <summary>
        /// Retrieve the set of triggers currently available within actions. A trigger is an extensibility point to which actions can be bound
        /// </summary>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A list containing the triggers.</returns>
        public Task<IList<Trigger>> GetAllTriggersAsync(CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<IList<Trigger>>(BuildUri($"{ActionsBasePath}/{TriggersPath}"), DefaultHeaders, _triggersConverters, cancellationToken);
        }

        /// <summary>
        /// Retrieve information about a specific execution of a trigger.
        /// </summary>
        /// <remarks>
        /// Relevant execution IDs will be included in tenant logs generated as part of that authentication flow.
        /// Executions will only be stored for 10 days after their creation.
        /// </remarks>
        /// <param name="id">The ID of the execution to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The retrieved execution.</returns>
        public Task<ActionExecution> GetExecutionAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<ActionExecution>(BuildUri($"{ActionsBasePath}/{ExecutionsPath}/{EncodePath(id)}"), DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieve all versions of an action.
        /// </summary>
        /// <remarks>
        /// An action version is created whenever an action is deployed. An action version is immutable, once created.
        /// </remarks>
        /// <param name="actionId">The ID of the action.</param>
        /// <param name="pagination">Specifies pagination info to use.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The retrieved versions of the specified action.</returns>
        public Task<IPagedList<ActionVersion>> GetAllVersionsAsync(string actionId, PaginationInfo pagination, CancellationToken cancellationToken = default)
        {
            var queryStrings = new Dictionary<string, string>
            {
                {"page", pagination.PageNo.ToString()},
                {"per_page", pagination.PerPage.ToString()},
                // {"include_totals", pagination.IncludeTotals.ToString()}
            };

            return Connection.GetAsync<IPagedList<ActionVersion>>(BuildUri($"{ActionsBasePath}/{ActionsPath}/{EncodePath(actionId)}/{VersionsPath}", queryStrings), DefaultHeaders, _versionsConverters, cancellationToken);
        }

        /// <summary>
        /// Retrieve a specific version of an action.
        /// </summary>
        /// <remarks>
        /// An action version is created whenever an action is deployed. An action version is immutable, once created.
        /// </remarks>
        /// <param name="actionId">The ID of the action.</param>
        /// <param name="versionId">The ID of the action version.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The retrieved version of the specified action.</returns>
        public Task<ActionVersion> GetVersionAsync(string actionId, string versionId, CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<ActionVersion>(BuildUri($"{ActionsBasePath}/{ActionsPath}/{EncodePath(actionId)}/{VersionsPath}/{EncodePath(versionId)}"), DefaultHeaders, cancellationToken: cancellationToken);
        }


        /// <summary>
        /// Retrieve the actions that are bound to a trigger.
        /// </summary>
        /// <remarks>
        /// Once an action is created and deployed, it must be attached (i.e. bound) to a trigger so that it will be executed as part of a flow.
        /// The list of actions returned reflects the order in which they will be executed during the appropriate flow.
        /// </remarks>
        /// <param name="triggerId">An actions extensibility point.</param>
        /// <param name="pagination">Specifies pagination info to use.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The retrieved trigger bindings.</returns>
        public Task<IPagedList<TriggerBinding>> GetAllTriggerBindingsAsync(string triggerId, PaginationInfo pagination, CancellationToken cancellationToken = default)
        {
            var queryStrings = new Dictionary<string, string>
            {
                {"page", pagination.PageNo.ToString()},
                {"per_page", pagination.PerPage.ToString()},
                // {"include_totals", pagination.IncludeTotals.ToString()}
            };

            return Connection.GetAsync<IPagedList<TriggerBinding>>(BuildUri($"{ActionsBasePath}/{TriggersPath}/{EncodePath(triggerId)}/{BindingsPath}", queryStrings), DefaultHeaders, _triggerBindingsConverters, cancellationToken);
        }

        /// <summary>
        /// Update the actions that are bound (i.e. attached) to a trigger.
        /// Once an action is created and deployed, it must be attached(i.e.bound) to a trigger so that it will be executed as part of a flow.
        /// The order in which the actions are provided will determine the order in which they are executed.
        /// </summary>
        /// <param name="triggerId">An actions extensibility point.</param>
        /// <param name="request">Specifies criteria to use when updating the trigger bindings.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The trigger bindings.</returns>
        public Task<IList<TriggerBinding>> UpdateTriggerBindingsAsync(string triggerId, UpdateTriggerBindingsRequest request, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<IList<TriggerBinding>>(new HttpMethod("PATCH"), BuildUri($"{ActionsBasePath}/{TriggersPath}/{EncodePath(triggerId)}/{BindingsPath}"), request, DefaultHeaders, null, _triggerBindingsListConverters, cancellationToken);
        }

        /// <summary>
        /// Deploy an action.
        /// </summary>
        /// <remarks>
        /// Deploying an action will create a new immutable version of the action. If the action is currently bound to a trigger,
        /// then the system will begin executing the newly deployed version of the action immediately.Otherwise, the action will only be executed as a part of a flow once it is bound to that flow.
        /// </remarks>
        /// <param name="id">The ID of the action to deploy.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The action version that was created.</returns>
        public Task<ActionVersion> DeployAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<ActionVersion>(HttpMethod.Post, BuildUri($"{ActionsBasePath}/{ActionsPath}/{EncodePath(id)}/{DeployPath}"), null, DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Performs the equivalent of a roll-back of an action to an earlier, specified version.
        /// </summary>
        /// <remarks>
        /// Creates a new, deployed action version that is identical to the specified version.
        /// If this action is currently bound to a trigger, the system will begin executing the newly-created version immediately.
        /// </remarks>
        /// <param name="actionId">The ID of the action.</param>
        /// <param name="versionId">The ID of the version to deploy.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task<ActionVersion> RollbackToVersionAsync(string actionId, string versionId, CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<ActionVersion>(HttpMethod.Post, BuildUri($"{ActionsBasePath}/{ActionsPath}/{EncodePath(actionId)}/versions/{versionId}/deploy"), new {}, DefaultHeaders, cancellationToken: cancellationToken);
        }
    }
}
