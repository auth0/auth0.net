using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(PreferredAuthenticationMethodEnum.PreferredAuthenticationMethodEnumSerializer)
)]
[Serializable]
public readonly record struct PreferredAuthenticationMethodEnum : IStringEnum
{
    public static readonly PreferredAuthenticationMethodEnum Voice = new(Values.Voice);

    public static readonly PreferredAuthenticationMethodEnum Sms = new(Values.Sms);

    public PreferredAuthenticationMethodEnum(string value)
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
    public static PreferredAuthenticationMethodEnum FromCustom(string value)
    {
        return new PreferredAuthenticationMethodEnum(value);
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

    public static bool operator ==(PreferredAuthenticationMethodEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PreferredAuthenticationMethodEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PreferredAuthenticationMethodEnum value) => value.Value;

    public static explicit operator PreferredAuthenticationMethodEnum(string value) => new(value);

    internal class PreferredAuthenticationMethodEnumSerializer
        : JsonConverter<PreferredAuthenticationMethodEnum>
    {
        public override PreferredAuthenticationMethodEnum Read(
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
            return new PreferredAuthenticationMethodEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PreferredAuthenticationMethodEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PreferredAuthenticationMethodEnum ReadAsPropertyName(
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
            return new PreferredAuthenticationMethodEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PreferredAuthenticationMethodEnum value,
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
        public const string Voice = "voice";

        public const string Sms = "sms";
    }
}
