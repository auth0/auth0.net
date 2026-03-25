using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Guardian.Factors.Duo;

[Serializable]
public record SetGuardianFactorDuoSettingsRequestContent
{
    [Optional]
    [JsonPropertyName("ikey")]
    public string? Ikey { get; set; }

    [Optional]
    [JsonPropertyName("skey")]
    public string? Skey { get; set; }

    [Optional]
    [JsonPropertyName("host")]
    public string? Host { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
