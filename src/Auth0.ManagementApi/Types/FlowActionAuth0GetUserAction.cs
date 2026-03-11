using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionAuth0GetUserAction>))]
[Serializable]
public readonly record struct FlowActionAuth0GetUserAction : IStringEnum
{
    public static readonly FlowActionAuth0GetUserAction GetUser = new(Values.GetUser);

    public FlowActionAuth0GetUserAction(string value)
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
    public static FlowActionAuth0GetUserAction FromCustom(string value)
    {
        return new FlowActionAuth0GetUserAction(value);
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

    public static bool operator ==(FlowActionAuth0GetUserAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionAuth0GetUserAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionAuth0GetUserAction value) => value.Value;

    public static explicit operator FlowActionAuth0GetUserAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string GetUser = "GET_USER";
    }
}
