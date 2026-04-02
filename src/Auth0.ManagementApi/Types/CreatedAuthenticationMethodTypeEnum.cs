using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(CreatedAuthenticationMethodTypeEnum.CreatedAuthenticationMethodTypeEnumSerializer)
)]
[Serializable]
public readonly record struct CreatedAuthenticationMethodTypeEnum : IStringEnum
{
    public static readonly CreatedAuthenticationMethodTypeEnum Phone = new(Values.Phone);

    public static readonly CreatedAuthenticationMethodTypeEnum Email = new(Values.Email);

    public static readonly CreatedAuthenticationMethodTypeEnum Totp = new(Values.Totp);

    public static readonly CreatedAuthenticationMethodTypeEnum WebauthnRoaming = new(
        Values.WebauthnRoaming
    );

    public CreatedAuthenticationMethodTypeEnum(string value)
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
    public static CreatedAuthenticationMethodTypeEnum FromCustom(string value)
    {
        return new CreatedAuthenticationMethodTypeEnum(value);
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

    public static bool operator ==(CreatedAuthenticationMethodTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CreatedAuthenticationMethodTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CreatedAuthenticationMethodTypeEnum value) =>
        value.Value;

    public static explicit operator CreatedAuthenticationMethodTypeEnum(string value) => new(value);

    internal class CreatedAuthenticationMethodTypeEnumSerializer
        : JsonConverter<CreatedAuthenticationMethodTypeEnum>
    {
        public override CreatedAuthenticationMethodTypeEnum Read(
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
            return new CreatedAuthenticationMethodTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreatedAuthenticationMethodTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreatedAuthenticationMethodTypeEnum ReadAsPropertyName(
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
            return new CreatedAuthenticationMethodTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreatedAuthenticationMethodTypeEnum value,
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
    }
}
