using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionZapierTriggerWebhookAction>))]
[Serializable]
public readonly record struct FlowActionZapierTriggerWebhookAction : IStringEnum
{
    public static readonly FlowActionZapierTriggerWebhookAction TriggerWebhook = new(
        Values.TriggerWebhook
    );

    public FlowActionZapierTriggerWebhookAction(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static FlowActionZapierTriggerWebhookAction FromCustom(string value)
    {
        return new FlowActionZapierTriggerWebhookAction(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(FlowActionZapierTriggerWebhookAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionZapierTriggerWebhookAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionZapierTriggerWebhookAction value) =>
        value.Value;

    public static explicit operator FlowActionZapierTriggerWebhookAction(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string TriggerWebhook = "TRIGGER_WEBHOOK";
    }
}
