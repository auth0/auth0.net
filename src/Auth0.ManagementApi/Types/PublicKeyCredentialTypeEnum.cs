using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<PublicKeyCredentialTypeEnum>))]
[Serializable]
public readonly record struct PublicKeyCredentialTypeEnum : IStringEnum
{
    public static readonly PublicKeyCredentialTypeEnum PublicKey = new(Values.PublicKey);

    public PublicKeyCredentialTypeEnum(string value)
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
    public static PublicKeyCredentialTypeEnum FromCustom(string value)
    {
        return new PublicKeyCredentialTypeEnum(value);
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

    public static bool operator ==(PublicKeyCredentialTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PublicKeyCredentialTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PublicKeyCredentialTypeEnum value) => value.Value;

    public static explicit operator PublicKeyCredentialTypeEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string PublicKey = "public_key";
    }
}
