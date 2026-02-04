using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<AuthenticationTypeEnum>))]
[Serializable]
public readonly record struct AuthenticationTypeEnum : IStringEnum
{
    public static readonly AuthenticationTypeEnum Phone = new(Values.Phone);

    public static readonly AuthenticationTypeEnum Email = new(Values.Email);

    public static readonly AuthenticationTypeEnum Totp = new(Values.Totp);

    public AuthenticationTypeEnum(string value)
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
    public static AuthenticationTypeEnum FromCustom(string value)
    {
        return new AuthenticationTypeEnum(value);
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

    public static bool operator ==(AuthenticationTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AuthenticationTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AuthenticationTypeEnum value) => value.Value;

    public static explicit operator AuthenticationTypeEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Phone = "phone";

        public const string Email = "email";

        public const string Totp = "totp";
    }
}
