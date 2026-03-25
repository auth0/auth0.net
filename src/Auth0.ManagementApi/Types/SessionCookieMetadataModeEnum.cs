using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(SessionCookieMetadataModeEnum.SessionCookieMetadataModeEnumSerializer))]
[Serializable]
public readonly record struct SessionCookieMetadataModeEnum : IStringEnum
{
    public static readonly SessionCookieMetadataModeEnum NonPersistent = new(Values.NonPersistent);

    public static readonly SessionCookieMetadataModeEnum Persistent = new(Values.Persistent);

    public SessionCookieMetadataModeEnum(string value)
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
    public static SessionCookieMetadataModeEnum FromCustom(string value)
    {
        return new SessionCookieMetadataModeEnum(value);
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

    public static bool operator ==(SessionCookieMetadataModeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SessionCookieMetadataModeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SessionCookieMetadataModeEnum value) => value.Value;

    public static explicit operator SessionCookieMetadataModeEnum(string value) => new(value);

    internal class SessionCookieMetadataModeEnumSerializer
        : JsonConverter<SessionCookieMetadataModeEnum>
    {
        public override SessionCookieMetadataModeEnum Read(
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
            return new SessionCookieMetadataModeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SessionCookieMetadataModeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SessionCookieMetadataModeEnum ReadAsPropertyName(
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
            return new SessionCookieMetadataModeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SessionCookieMetadataModeEnum value,
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
        public const string NonPersistent = "non-persistent";

        public const string Persistent = "persistent";
    }
}
