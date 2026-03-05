using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Custom scripts to transform user profile data or modify OAuth1 flow behavior
/// </summary>
[Serializable]
public record ConnectionScriptsOAuth1 : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Custom JavaScript function to retrieve and transform user profile data from the identity provider. Called with the access token and token exchange response. Must return a user profile object. Executed in a sandboxed environment. If not provided, an empty profile object is used.
    /// </summary>
    [Optional]
    [JsonPropertyName("fetchUserProfile")]
    public string? FetchUserProfile { get; set; }

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
