using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Actions;

[Serializable]
public record UpdateActionModuleRequestContent
{
    /// <summary>
    /// The source code of the action module.
    /// </summary>
    [Optional]
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    /// <summary>
    /// The secrets to associate with the action module.
    /// </summary>
    [Optional]
    [JsonPropertyName("secrets")]
    public IEnumerable<ActionModuleSecretRequest>? Secrets { get; set; }

    /// <summary>
    /// The npm dependencies of the action module.
    /// </summary>
    [Optional]
    [JsonPropertyName("dependencies")]
    public IEnumerable<ActionModuleDependencyRequest>? Dependencies { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
