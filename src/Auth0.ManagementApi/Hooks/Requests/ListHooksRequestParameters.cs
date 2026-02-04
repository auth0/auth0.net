using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ListHooksRequestParameters
{
    /// <summary>
    /// Page index of the results to return. First page is 0.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Page { get; set; } = 0;

    /// <summary>
    /// Number of results per page.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> PerPage { get; set; } = 50;

    /// <summary>
    /// Return results inside an object that contains the total result count (true) or as a direct array of results (false, default).
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IncludeTotals { get; set; } = true;

    /// <summary>
    /// Optional filter on whether a hook is enabled (true) or disabled (false).
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> Enabled { get; set; }

    /// <summary>
    /// Comma-separated list of fields to include in the result. Leave empty to retrieve all fields.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Fields { get; set; }

    /// <summary>
    /// Retrieves hooks that match the trigger
    /// </summary>
    [JsonIgnore]
    public Optional<HookTriggerIdEnum?> TriggerId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
