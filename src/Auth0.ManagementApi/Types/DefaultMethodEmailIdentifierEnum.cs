using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(DefaultMethodEmailIdentifierEnum.DefaultMethodEmailIdentifierEnumSerializer))]
[Serializable]
public readonly record struct DefaultMethodEmailIdentifierEnum : IStringEnum
{
    public static readonly DefaultMethodEmailIdentifierEnum Password = new(Values.Password);

    public static readonly DefaultMethodEmailIdentifierEnum EmailOtp = new(Values.EmailOtp);

    public DefaultMethodEmailIdentifierEnum(string value)
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
    public static DefaultMethodEmailIdentifierEnum FromCustom(string value)
    {
        return new DefaultMethodEmailIdentifierEnum(value);
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

    public static bool operator ==(DefaultMethodEmailIdentifierEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DefaultMethodEmailIdentifierEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DefaultMethodEmailIdentifierEnum value) => value.Value;

    public static explicit operator DefaultMethodEmailIdentifierEnum(string value) => new(value);

    internal class DefaultMethodEmailIdentifierEnumSerializer
        : JsonConverter<DefaultMethodEmailIdentifierEnum>
    {
        public override DefaultMethodEmailIdentifierEnum Read(
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
            return new DefaultMethodEmailIdentifierEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DefaultMethodEmailIdentifierEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DefaultMethodEmailIdentifierEnum ReadAsPropertyName(
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
            return new DefaultMethodEmailIdentifierEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DefaultMethodEmailIdentifierEnum value,
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
        public const string Password = "password";

        public const string EmailOtp = "email_otp";
    }
}
