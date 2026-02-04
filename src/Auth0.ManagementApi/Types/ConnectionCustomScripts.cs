using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// A map of scripts used to integrate with a custom database.
/// </summary>
[Serializable]
public record ConnectionCustomScripts : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("login")]
    public string? Login { get; set; }

    [Optional]
    [JsonPropertyName("get_user")]
    public string? GetUser { get; set; }

    [Optional]
    [JsonPropertyName("delete")]
    public string? Delete { get; set; }

    [Optional]
    [JsonPropertyName("change_password")]
    public string? ChangePassword { get; set; }

    [Optional]
    [JsonPropertyName("verify")]
    public string? Verify { get; set; }

    [Optional]
    [JsonPropertyName("create")]
    public string? Create { get; set; }

    [Optional]
    [JsonPropertyName("change_username")]
    public string? ChangeUsername { get; set; }

    [Optional]
    [JsonPropertyName("change_email")]
    public string? ChangeEmail { get; set; }

    [Optional]
    [JsonPropertyName("change_phone_number")]
    public string? ChangePhoneNumber { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
