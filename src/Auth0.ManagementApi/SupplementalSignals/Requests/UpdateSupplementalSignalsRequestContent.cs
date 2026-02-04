using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateSupplementalSignalsRequestContent
{
    /// <summary>
    /// Indicates if incoming Akamai Headers should be processed
    /// </summary>
    [JsonPropertyName("akamai_enabled")]
    public required bool AkamaiEnabled { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
