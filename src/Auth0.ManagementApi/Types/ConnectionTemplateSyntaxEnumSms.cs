using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ConnectionTemplateSyntaxEnumSms.ConnectionTemplateSyntaxEnumSmsSerializer))]
[Serializable]
public readonly record struct ConnectionTemplateSyntaxEnumSms : IStringEnum
{
    public static readonly ConnectionTemplateSyntaxEnumSms Liquid = new(Values.Liquid);

    public static readonly ConnectionTemplateSyntaxEnumSms MdWithMacros = new(Values.MdWithMacros);

    public ConnectionTemplateSyntaxEnumSms(string value)
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
    public static ConnectionTemplateSyntaxEnumSms FromCustom(string value)
    {
        return new ConnectionTemplateSyntaxEnumSms(value);
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

    public static bool operator ==(ConnectionTemplateSyntaxEnumSms value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionTemplateSyntaxEnumSms value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionTemplateSyntaxEnumSms value) => value.Value;

    public static explicit operator ConnectionTemplateSyntaxEnumSms(string value) => new(value);

    internal class ConnectionTemplateSyntaxEnumSmsSerializer
        : JsonConverter<ConnectionTemplateSyntaxEnumSms>
    {
        public override ConnectionTemplateSyntaxEnumSms Read(
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
            return new ConnectionTemplateSyntaxEnumSms(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionTemplateSyntaxEnumSms value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionTemplateSyntaxEnumSms ReadAsPropertyName(
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
            return new ConnectionTemplateSyntaxEnumSms(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionTemplateSyntaxEnumSms value,
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
        public const string Liquid = "liquid";

        public const string MdWithMacros = "md_with_macros";
    }
}
