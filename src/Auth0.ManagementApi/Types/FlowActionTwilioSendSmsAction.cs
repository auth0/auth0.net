using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionTwilioSendSmsAction>))]
[Serializable]
public readonly record struct FlowActionTwilioSendSmsAction : IStringEnum
{
    public static readonly FlowActionTwilioSendSmsAction SendSms = new(Values.SendSms);

    public FlowActionTwilioSendSmsAction(string value)
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
    public static FlowActionTwilioSendSmsAction FromCustom(string value)
    {
        return new FlowActionTwilioSendSmsAction(value);
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

    public static bool operator ==(FlowActionTwilioSendSmsAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionTwilioSendSmsAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionTwilioSendSmsAction value) => value.Value;

    public static explicit operator FlowActionTwilioSendSmsAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string SendSms = "SEND_SMS";
    }
}
