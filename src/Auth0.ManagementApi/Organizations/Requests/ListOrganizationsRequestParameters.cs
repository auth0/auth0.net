using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record ListOrganizationsRequestParameters
{
    /// <summary>
    /// Return results inside an object that contains the total result count (true) or as a direct array of results (false, default).
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IncludeTotals { get; set; } = true;

    /// <summary>
    /// Optional Id from which to start selection.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> From { get; set; }

    /// <summary>
    /// Number of results per page. Defaults to 50.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Take { get; set; } = 50;

    /// <summary>
    /// Field to sort by. Use <c>field:order</c> where order is <c>1</c> for ascending and <c>-1</c> for descending. e.g. <c>created_at:1</c>. We currently support sorting by the following fields: <c>name</c>, <c>display_name</c> and <c>created_at</c>.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Sort { get; set; }

    /// <summary>
    /// Client ID. When set, each returned organization that has an association with this client gains a <c>client</c> object describing it; organizations without one omit the field.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> IncludeClientAssociationFor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
