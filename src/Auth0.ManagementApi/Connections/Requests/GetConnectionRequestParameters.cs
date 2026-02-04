using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record GetConnectionRequestParameters
{
    /// <summary>
    /// A comma separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Fields { get; set; }

    /// <summary>
    /// <code>true</code> if the fields specified are to be included in the result, <code>false</code> otherwise (defaults to <code>true</code>)
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IncludeFields { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
