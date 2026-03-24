using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionMailjetSendEmailAction>))]
[Serializable]
public readonly record struct FlowActionMailjetSendEmailAction : IStringEnum
{
    public static readonly FlowActionMailjetSendEmailAction SendEmail = new(Values.SendEmail);

    public FlowActionMailjetSendEmailAction(string value)
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
    public static FlowActionMailjetSendEmailAction FromCustom(string value)
    {
        return new FlowActionMailjetSendEmailAction(value);
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

    public static bool operator ==(FlowActionMailjetSendEmailAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionMailjetSendEmailAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionMailjetSendEmailAction value) => value.Value;

    public static explicit operator FlowActionMailjetSendEmailAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string SendEmail = "SEND_EMAIL";
    }
}
