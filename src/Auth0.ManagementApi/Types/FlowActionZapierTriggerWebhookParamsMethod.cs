using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionZapierTriggerWebhookParamsMethod>))]
[Serializable]
public readonly record struct FlowActionZapierTriggerWebhookParamsMethod : IStringEnum
{
    public static readonly FlowActionZapierTriggerWebhookParamsMethod Get = new(Values.Get);

    public static readonly FlowActionZapierTriggerWebhookParamsMethod Post = new(Values.Post);

    public static readonly FlowActionZapierTriggerWebhookParamsMethod Put = new(Values.Put);

    public FlowActionZapierTriggerWebhookParamsMethod(string value)
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
    public static FlowActionZapierTriggerWebhookParamsMethod FromCustom(string value)
    {
        return new FlowActionZapierTriggerWebhookParamsMethod(value);
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

    public static bool operator ==(
        FlowActionZapierTriggerWebhookParamsMethod value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowActionZapierTriggerWebhookParamsMethod value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionZapierTriggerWebhookParamsMethod value) =>
        value.Value;

    public static explicit operator FlowActionZapierTriggerWebhookParamsMethod(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Get = "GET";

        public const string Post = "POST";

        public const string Put = "PUT";
    }
}
