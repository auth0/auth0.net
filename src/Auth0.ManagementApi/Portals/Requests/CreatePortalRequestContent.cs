using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record CreatePortalRequestContent
{
    [JsonPropertyName("slug")]
    public required string Slug { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("client")]
    public required PortalClientSecretPostRequest Client { get; set; }

    [Optional]
    [JsonPropertyName("navigation")]
    public PortalNavigation? Navigation { get; set; }

    [Optional]
    [JsonPropertyName("pages")]
    public PortalPagesByType? Pages { get; set; }

    [Optional]
    [JsonPropertyName("custom_code")]
    public PortalCustomCode? CustomCode { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
