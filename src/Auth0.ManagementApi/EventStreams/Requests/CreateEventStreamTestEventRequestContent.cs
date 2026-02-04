using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateEventStreamTestEventRequestContent
{
    [JsonPropertyName("event_type")]
    public required EventStreamTestEventTypeEnum EventType { get; set; }

    [Optional]
    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
