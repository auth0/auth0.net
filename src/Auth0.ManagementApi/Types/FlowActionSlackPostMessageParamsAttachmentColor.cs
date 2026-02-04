using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionSlackPostMessageParamsAttachmentColor>))]
[Serializable]
public readonly record struct FlowActionSlackPostMessageParamsAttachmentColor : IStringEnum
{
    public static readonly FlowActionSlackPostMessageParamsAttachmentColor Good = new(Values.Good);

    public static readonly FlowActionSlackPostMessageParamsAttachmentColor Warning = new(
        Values.Warning
    );

    public static readonly FlowActionSlackPostMessageParamsAttachmentColor Danger = new(
        Values.Danger
    );

    public FlowActionSlackPostMessageParamsAttachmentColor(string value)
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
    public static FlowActionSlackPostMessageParamsAttachmentColor FromCustom(string value)
    {
        return new FlowActionSlackPostMessageParamsAttachmentColor(value);
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
        FlowActionSlackPostMessageParamsAttachmentColor value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowActionSlackPostMessageParamsAttachmentColor value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionSlackPostMessageParamsAttachmentColor value) =>
        value.Value;

    public static explicit operator FlowActionSlackPostMessageParamsAttachmentColor(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Good = "GOOD";

        public const string Warning = "WARNING";

        public const string Danger = "DANGER";
    }
}
