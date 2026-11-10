using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdatePortalRequestContent
{
    [Optional]
    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Optional]
    [JsonPropertyName("client")]
    public PortalClientSecretPostRequest? Client { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("navigation")]
    public Optional<PortalNavigation?> Navigation { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("pages")]
    public Optional<PortalPagesByType?> Pages { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("custom_code")]
    public Optional<PortalCustomCode?> CustomCode { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
