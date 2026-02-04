using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record BreachedPasswordDetectionPreUserRegistrationStage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Action to take when a breached password is detected during a signup.
    ///               Possible values: <code>block</code>, <code>admin_notification</code>.
    /// </summary>
    [Optional]
    [JsonPropertyName("shields")]
    public IEnumerable<BreachedPasswordDetectionPreUserRegistrationShieldsEnum>? Shields { get; set; }

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
