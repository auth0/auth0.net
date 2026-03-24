using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record SetDefaultCustomDomainRequestContent
{
    /// <summary>
    /// The domain to set as the default custom domain. Must be a verified custom domain or the canonical domain.
    /// </summary>
    [JsonPropertyName("domain")]
    public required string Domain { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
