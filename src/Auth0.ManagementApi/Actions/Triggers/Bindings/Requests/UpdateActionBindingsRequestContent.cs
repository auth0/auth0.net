using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Actions.Triggers;

[Serializable]
public record UpdateActionBindingsRequestContent
{
    /// <summary>
    /// The actions that will be bound to this trigger. The order in which they are included will be the order in which they are executed.
    /// </summary>
    [Optional]
    [JsonPropertyName("bindings")]
    public IEnumerable<ActionBindingWithRef>? Bindings { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
