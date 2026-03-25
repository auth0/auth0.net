using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Actions;

[Serializable]
public record RollbackActionModuleRequestParameters
{
    /// <summary>
    /// The unique ID of the module version to roll back to.
    /// </summary>
    [JsonPropertyName("module_version_id")]
    public required string ModuleVersionId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
