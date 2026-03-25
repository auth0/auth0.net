using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(CreatedUserAuthenticationMethodTypeEnum.CreatedUserAuthenticationMethodTypeEnumSerializer)
)]
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

    internal class CreatedUserAuthenticationMethodTypeEnumSerializer
        : JsonConverter<CreatedUserAuthenticationMethodTypeEnum>
    {
        public override CreatedUserAuthenticationMethodTypeEnum Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new CreatedUserAuthenticationMethodTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatedUserAuthenticationMethodTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatedUserAuthenticationMethodTypeEnum ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new CreatedUserAuthenticationMethodTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatedUserAuthenticationMethodTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

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
