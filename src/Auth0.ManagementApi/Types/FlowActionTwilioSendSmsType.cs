using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionTwilioSendSmsType>))]
[Serializable]
public readonly record struct FlowActionTwilioSendSmsType : IStringEnum
{
    public static readonly FlowActionTwilioSendSmsType Twilio = new(Values.Twilio);

    public FlowActionTwilioSendSmsType(string value)
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
    public static FlowActionTwilioSendSmsType FromCustom(string value)
    {
        return new FlowActionTwilioSendSmsType(value);
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

    public static bool operator ==(FlowActionTwilioSendSmsType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionTwilioSendSmsType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionTwilioSendSmsType value) => value.Value;

    public static explicit operator FlowActionTwilioSendSmsType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Twilio = "TWILIO";
    }
}
