using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record DeleteActionRequestParameters
{
    /// <summary>
    /// Force action deletion detaching bindings
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> Force { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
