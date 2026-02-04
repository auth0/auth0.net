using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CustomSigningKeyCurveEnum>))]
[Serializable]
public readonly record struct CustomSigningKeyCurveEnum : IStringEnum
{
    public static readonly CustomSigningKeyCurveEnum P256 = new(Values.P256);

    public static readonly CustomSigningKeyCurveEnum P384 = new(Values.P384);

    public static readonly CustomSigningKeyCurveEnum P521 = new(Values.P521);

    public CustomSigningKeyCurveEnum(string value)
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
    public static CustomSigningKeyCurveEnum FromCustom(string value)
    {
        return new CustomSigningKeyCurveEnum(value);
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

    public static bool operator ==(CustomSigningKeyCurveEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomSigningKeyCurveEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomSigningKeyCurveEnum value) => value.Value;

    public static explicit operator CustomSigningKeyCurveEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string P256 = "P-256";

        public const string P384 = "P-384";

        public const string P521 = "P-521";
    }
}
