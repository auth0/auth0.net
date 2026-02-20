using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ListOrganizationsRequestParameters
{
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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
