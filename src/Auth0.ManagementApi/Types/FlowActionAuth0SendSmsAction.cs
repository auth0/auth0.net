using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionAuth0SendSmsAction>))]
[Serializable]
public readonly record struct FlowActionAuth0SendSmsAction : IStringEnum
{
    public static readonly FlowActionAuth0SendSmsAction SendSms = new(Values.SendSms);

    public FlowActionAuth0SendSmsAction(string value)
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
    public static FlowActionAuth0SendSmsAction FromCustom(string value)
    {
        return new FlowActionAuth0SendSmsAction(value);
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

    public static bool operator ==(FlowActionAuth0SendSmsAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionAuth0SendSmsAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionAuth0SendSmsAction value) => value.Value;

    public static explicit operator FlowActionAuth0SendSmsAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string SendSms = "SEND_SMS";
    }
}
