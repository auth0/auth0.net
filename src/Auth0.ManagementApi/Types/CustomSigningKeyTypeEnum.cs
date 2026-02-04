using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CustomSigningKeyTypeEnum>))]
[Serializable]
public readonly record struct CustomSigningKeyTypeEnum : IStringEnum
{
    public static readonly CustomSigningKeyTypeEnum Ec = new(Values.Ec);

    public static readonly CustomSigningKeyTypeEnum Rsa = new(Values.Rsa);

    public CustomSigningKeyTypeEnum(string value)
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
    public static CustomSigningKeyTypeEnum FromCustom(string value)
    {
        return new CustomSigningKeyTypeEnum(value);
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

    public static bool operator ==(CustomSigningKeyTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomSigningKeyTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomSigningKeyTypeEnum value) => value.Value;

    public static explicit operator CustomSigningKeyTypeEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Ec = "EC";

        public const string Rsa = "RSA";
    }
}
