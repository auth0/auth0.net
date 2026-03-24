using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionAuth0SendRequestAction>))]
[Serializable]
public readonly record struct FlowActionAuth0SendRequestAction : IStringEnum
{
    public static readonly FlowActionAuth0SendRequestAction SendRequest = new(Values.SendRequest);

    public FlowActionAuth0SendRequestAction(string value)
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
    public static FlowActionAuth0SendRequestAction FromCustom(string value)
    {
        return new FlowActionAuth0SendRequestAction(value);
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

    public static bool operator ==(FlowActionAuth0SendRequestAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionAuth0SendRequestAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionAuth0SendRequestAction value) => value.Value;

    public static explicit operator FlowActionAuth0SendRequestAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string SendRequest = "SEND_REQUEST";
    }
}
