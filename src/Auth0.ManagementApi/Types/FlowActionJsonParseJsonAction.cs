using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionJsonParseJsonAction>))]
[Serializable]
public readonly record struct FlowActionJsonParseJsonAction : IStringEnum
{
    public static readonly FlowActionJsonParseJsonAction ParseJson = new(Values.ParseJson);

    public FlowActionJsonParseJsonAction(string value)
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
    public static FlowActionJsonParseJsonAction FromCustom(string value)
    {
        return new FlowActionJsonParseJsonAction(value);
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

    public static bool operator ==(FlowActionJsonParseJsonAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionJsonParseJsonAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionJsonParseJsonAction value) => value.Value;

    public static explicit operator FlowActionJsonParseJsonAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string ParseJson = "PARSE_JSON";
    }
}
