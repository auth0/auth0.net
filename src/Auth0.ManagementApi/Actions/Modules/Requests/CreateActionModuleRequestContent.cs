using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Actions;

[Serializable]
public record CreateActionModuleRequestContent
{
    /// <summary>
    /// The name of the action module.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The source code of the action module.
    /// </summary>
    [JsonPropertyName("code")]
    public required string Code { get; set; }

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

    /// <summary>
    /// The API version of the module.
    /// </summary>
    [Optional]
    [JsonPropertyName("api_version")]
    public string? ApiVersion { get; set; }

    /// <summary>
    /// Whether to publish the module immediately after creation.
    /// </summary>
    [Optional]
    [JsonPropertyName("publish")]
    public bool? Publish { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
