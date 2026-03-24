using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionTelegramSendMessageAction>))]
[Serializable]
public readonly record struct FlowActionTelegramSendMessageAction : IStringEnum
{
    public static readonly FlowActionTelegramSendMessageAction SendMessage = new(
        Values.SendMessage
    );

    public FlowActionTelegramSendMessageAction(string value)
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
    public static FlowActionTelegramSendMessageAction FromCustom(string value)
    {
        return new FlowActionTelegramSendMessageAction(value);
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

    public static bool operator ==(FlowActionTelegramSendMessageAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionTelegramSendMessageAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionTelegramSendMessageAction value) =>
        value.Value;

    public static explicit operator FlowActionTelegramSendMessageAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string SendMessage = "SEND_MESSAGE";
    }
}
