using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(UserAuthenticationMethodPropertiesEnum.UserAuthenticationMethodPropertiesEnumSerializer)
)]
[Serializable]
public readonly record struct UserAuthenticationMethodPropertiesEnum : IStringEnum
{
    public static readonly UserAuthenticationMethodPropertiesEnum Totp = new(Values.Totp);

    public static readonly UserAuthenticationMethodPropertiesEnum Push = new(Values.Push);

    public static readonly UserAuthenticationMethodPropertiesEnum Sms = new(Values.Sms);

    public static readonly UserAuthenticationMethodPropertiesEnum Voice = new(Values.Voice);

    public UserAuthenticationMethodPropertiesEnum(string value)
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
    public static UserAuthenticationMethodPropertiesEnum FromCustom(string value)
    {
        return new UserAuthenticationMethodPropertiesEnum(value);
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

    public static bool operator ==(UserAuthenticationMethodPropertiesEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UserAuthenticationMethodPropertiesEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UserAuthenticationMethodPropertiesEnum value) =>
        value.Value;

    public static explicit operator UserAuthenticationMethodPropertiesEnum(string value) =>
        new(value);

    internal class UserAuthenticationMethodPropertiesEnumSerializer
        : JsonConverter<UserAuthenticationMethodPropertiesEnum>
    {
        public override UserAuthenticationMethodPropertiesEnum Read(
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
            return new UserAuthenticationMethodPropertiesEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UserAuthenticationMethodPropertiesEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UserAuthenticationMethodPropertiesEnum ReadAsPropertyName(
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
            return new UserAuthenticationMethodPropertiesEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UserAuthenticationMethodPropertiesEnum value,
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
        public const string Totp = "totp";

        public const string Push = "push";

        public const string Sms = "sms";

        public const string Voice = "voice";
    }
}
