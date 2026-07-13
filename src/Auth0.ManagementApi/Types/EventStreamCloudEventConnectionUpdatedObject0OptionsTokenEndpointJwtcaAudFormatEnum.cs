using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum.EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum Issuer =
        new(Values.Issuer);

    public static readonly EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum TokenEndpoint =
        new(Values.TokenEndpoint);

    public EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum(
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
    public static EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum(
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
        EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum>
    {
        public override EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum Read(
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
            return new EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject0OptionsTokenEndpointJwtcaAudFormatEnum value,
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
