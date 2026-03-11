using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionAuth0MakeCallAction>))]
[Serializable]
public readonly record struct FlowActionAuth0MakeCallAction : IStringEnum
{
    public static readonly FlowActionAuth0MakeCallAction MakeCall = new(Values.MakeCall);

    public FlowActionAuth0MakeCallAction(string value)
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
    public static FlowActionAuth0MakeCallAction FromCustom(string value)
    {
        return new FlowActionAuth0MakeCallAction(value);
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

    public static bool operator ==(FlowActionAuth0MakeCallAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionAuth0MakeCallAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionAuth0MakeCallAction value) => value.Value;

    public static explicit operator FlowActionAuth0MakeCallAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string MakeCall = "MAKE_CALL";
    }
}
