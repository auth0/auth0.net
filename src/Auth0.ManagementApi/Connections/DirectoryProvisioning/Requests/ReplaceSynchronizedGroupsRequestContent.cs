using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Connections;

[Serializable]
public record ReplaceSynchronizedGroupsRequestContent
{
    /// <summary>
    /// Array of Google Workspace Directory group objects to synchronize.
    /// </summary>
    [JsonPropertyName("groups")]
    public IEnumerable<SynchronizedGroupPayload> Groups { get; set; } =
        new List<SynchronizedGroupPayload>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
