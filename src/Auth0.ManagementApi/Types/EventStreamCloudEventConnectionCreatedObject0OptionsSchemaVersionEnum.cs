using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum.EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum Openid100 =
        new(Values.Openid100);

    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum OidcV4 =
        new(Values.OidcV4);

    public EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum(string value)
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
    public static EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum(value);
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

    public static bool operator ==(
        EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject0OptionsSchemaVersionEnum value,
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
        public const string Openid100 = "openid-1.0.0";

        public const string OidcV4 = "oidc-v4";
    }
}
