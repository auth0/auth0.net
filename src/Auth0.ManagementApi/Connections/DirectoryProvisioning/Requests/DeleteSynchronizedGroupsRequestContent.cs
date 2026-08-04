using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Connections;

[Serializable]
public record DeleteSynchronizedGroupsRequestContent
{
    /// <summary>
    /// Array of groups to remove from the selection set.
    /// </summary>
    [JsonPropertyName("groups")]
    public IEnumerable<SynchronizedGroupSelectionId> Groups { get; set; } =
        new List<SynchronizedGroupSelectionId>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
