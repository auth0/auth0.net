using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum.EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum Openid100 =
        new(Values.Openid100);

    public static readonly EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum OidcV4 =
        new(Values.OidcV4);

    public EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum(string value)
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
    public static EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum(value);
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
        EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum>
    {
        public override EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum Read(
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
            return new EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject1OptionsSchemaVersionEnum value,
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
