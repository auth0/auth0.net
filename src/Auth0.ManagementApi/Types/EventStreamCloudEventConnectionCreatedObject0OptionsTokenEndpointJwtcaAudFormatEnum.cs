using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum.EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum Issuer =
        new(Values.Issuer);

    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum TokenEndpoint =
        new(Values.TokenEndpoint);

    public EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum(
        string value
    )
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
    public static EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum(
            value
        );
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
        EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject0OptionsTokenEndpointJwtcaAudFormatEnum value,
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
        public const string Issuer = "issuer";

        public const string TokenEndpoint = "token_endpoint";
    }
}
