using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionJwtSignJwtType>))]
[Serializable]
public readonly record struct FlowActionJwtSignJwtType : IStringEnum
{
    public static readonly FlowActionJwtSignJwtType Jwt = new(Values.Jwt);

    public FlowActionJwtSignJwtType(string value)
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
    public static FlowActionJwtSignJwtType FromCustom(string value)
    {
        return new FlowActionJwtSignJwtType(value);
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

    public static bool operator ==(FlowActionJwtSignJwtType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionJwtSignJwtType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionJwtSignJwtType value) => value.Value;

    public static explicit operator FlowActionJwtSignJwtType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Jwt = "JWT";
    }
}
