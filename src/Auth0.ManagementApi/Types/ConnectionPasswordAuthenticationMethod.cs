using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Password authentication enablement
/// </summary>
[Serializable]
public record ConnectionPasswordAuthenticationMethod : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Determines whether passwords are enabled
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [Optional]
    [JsonPropertyName("api_behavior")]
    public ConnectionApiBehaviorEnum? ApiBehavior { get; set; }

    [Optional]
    [JsonPropertyName("signup_behavior")]
    public ConnectionSignupBehaviorEnum? SignupBehavior { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
