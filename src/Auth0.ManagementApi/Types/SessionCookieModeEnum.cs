using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(SessionCookieModeEnum.SessionCookieModeEnumSerializer))]
[Serializable]
public readonly record struct SessionCookieModeEnum : IStringEnum
{
    public static readonly SessionCookieModeEnum Persistent = new(Values.Persistent);

    public static readonly SessionCookieModeEnum NonPersistent = new(Values.NonPersistent);

    public SessionCookieModeEnum(string value)
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
    public static SessionCookieModeEnum FromCustom(string value)
    {
        return new SessionCookieModeEnum(value);
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

    public static bool operator ==(SessionCookieModeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SessionCookieModeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SessionCookieModeEnum value) => value.Value;

    public static explicit operator SessionCookieModeEnum(string value) => new(value);

    internal class SessionCookieModeEnumSerializer : JsonConverter<SessionCookieModeEnum>
    {
        public override SessionCookieModeEnum Read(
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
            return new SessionCookieModeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SessionCookieModeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SessionCookieModeEnum ReadAsPropertyName(
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
            return new SessionCookieModeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SessionCookieModeEnum value,
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
        public const string Persistent = "persistent";

        public const string NonPersistent = "non-persistent";
    }
}
