using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CreatedUserAuthenticationMethodTypeEnum>))]
[Serializable]
public readonly record struct CreatedUserAuthenticationMethodTypeEnum : IStringEnum
{
    public static readonly CreatedUserAuthenticationMethodTypeEnum Phone = new(Values.Phone);

    public static readonly CreatedUserAuthenticationMethodTypeEnum Email = new(Values.Email);

    public static readonly CreatedUserAuthenticationMethodTypeEnum Totp = new(Values.Totp);

    public static readonly CreatedUserAuthenticationMethodTypeEnum WebauthnRoaming = new(
        Values.WebauthnRoaming
    );

    public static readonly CreatedUserAuthenticationMethodTypeEnum Passkey = new(Values.Passkey);

    public CreatedUserAuthenticationMethodTypeEnum(string value)
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
    public static CreatedUserAuthenticationMethodTypeEnum FromCustom(string value)
    {
        return new CreatedUserAuthenticationMethodTypeEnum(value);
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

    public static bool operator ==(CreatedUserAuthenticationMethodTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreatedUserAuthenticationMethodTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreatedUserAuthenticationMethodTypeEnum value) =>
        value.Value;

    public static explicit operator CreatedUserAuthenticationMethodTypeEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Phone = "phone";

        public const string Email = "email";

        public const string Totp = "totp";

        public const string WebauthnRoaming = "webauthn-roaming";

        public const string Passkey = "passkey";
    }
}
