using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateBrandingRequestContent
{
    [Nullable, Optional]
    [JsonPropertyName("colors")]
    public Optional<UpdateBrandingColors?> Colors { get; set; }

    /// <summary>
    /// URL for the favicon. Must use HTTPS.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("favicon_url")]
    public Optional<string?> FaviconUrl { get; set; }

    /// <summary>
    /// URL for the logo. Must use HTTPS.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("logo_url")]
    public Optional<string?> LogoUrl { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("font")]
    public Optional<UpdateBrandingFont?> Font { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
