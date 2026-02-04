using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Flows.Vault;

[Serializable]
public record UpdateFlowsVaultConnectionRequestContent
{
    /// <summary>
    /// Flows Vault Connection name.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Optional]
    [JsonPropertyName("setup")]
    public UpdateFlowsVaultConnectionSetup? Setup { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
