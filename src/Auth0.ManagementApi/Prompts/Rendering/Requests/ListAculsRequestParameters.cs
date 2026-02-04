using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Prompts;

[Serializable]
public record ListAculsRequestParameters
{
    /// <summary>
    /// Comma-separated list of fields to include or exclude (based on value provided for include_fields) in the result. Leave empty to retrieve all fields.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Fields { get; set; }

    /// <summary>
    /// Whether specified fields are to be included (default: true) or excluded (false).
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IncludeFields { get; set; }

    /// <summary>
    /// Page index of the results to return. First page is 0.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Page { get; set; } = 0;

    /// <summary>
    /// Number of results per page. Maximum value is 100, default value is 50.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> PerPage { get; set; } = 50;

    /// <summary>
    /// Return results inside an object that contains the total configuration count (true) or as a direct array of results (false, default).
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IncludeTotals { get; set; } = true;

    /// <summary>
    /// Name of the prompt to filter by
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Prompt { get; set; }

    /// <summary>
    /// Name of the screen to filter by
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Screen { get; set; }

    /// <summary>
    /// Rendering mode to filter by
    /// </summary>
    [JsonIgnore]
    public Optional<AculRenderingModeEnum?> RenderingMode { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
