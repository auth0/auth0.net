using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionEmailVerifyEmailType>))]
[Serializable]
public readonly record struct FlowActionEmailVerifyEmailType : IStringEnum
{
    public static readonly FlowActionEmailVerifyEmailType Email = new(Values.Email);

    public FlowActionEmailVerifyEmailType(string value)
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
    public static FlowActionEmailVerifyEmailType FromCustom(string value)
    {
        return new FlowActionEmailVerifyEmailType(value);
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

    public static bool operator ==(FlowActionEmailVerifyEmailType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionEmailVerifyEmailType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionEmailVerifyEmailType value) => value.Value;

    public static explicit operator FlowActionEmailVerifyEmailType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Email = "EMAIL";
    }
}
