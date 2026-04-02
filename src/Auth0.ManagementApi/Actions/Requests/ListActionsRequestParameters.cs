using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record ListActionsRequestParameters
{
    /// <summary>
    /// An actions extensibility point.
    /// </summary>
    [JsonIgnore]
    public Optional<ActionTriggerTypeEnum?> TriggerId { get; set; }

    /// <summary>
    /// The name of the action to retrieve.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> ActionName { get; set; }

    /// <summary>
    /// Optional filter to only retrieve actions that are deployed.
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> Deployed { get; set; }

    /// <summary>
    /// Use this field to request a specific page of the list results.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Page { get; set; } = 0;

    /// <summary>
    /// The maximum number of results to be returned by the server in single response. 20 by default
    /// </summary>
    [JsonIgnore]
    public Optional<int?> PerPage { get; set; } = 50;

    /// <summary>
    /// Optional. When true, return only installed actions. When false, return only custom actions. Returns all actions by default.
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> Installed { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
