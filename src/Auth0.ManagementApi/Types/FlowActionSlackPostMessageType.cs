using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionSlackPostMessageType>))]
[Serializable]
public readonly record struct FlowActionSlackPostMessageType : IStringEnum
{
    public static readonly FlowActionSlackPostMessageType Slack = new(Values.Slack);

    public FlowActionSlackPostMessageType(string value)
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
    public static FlowActionSlackPostMessageType FromCustom(string value)
    {
        return new FlowActionSlackPostMessageType(value);
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

    public static bool operator ==(FlowActionSlackPostMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionSlackPostMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionSlackPostMessageType value) => value.Value;

    public static explicit operator FlowActionSlackPostMessageType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Slack = "SLACK";
    }
}
