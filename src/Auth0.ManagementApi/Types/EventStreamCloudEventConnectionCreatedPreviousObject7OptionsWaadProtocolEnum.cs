using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum.EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum WsFederation =
        new(Values.WsFederation);

    public static readonly EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum OpenidConnect =
        new(Values.OpenidConnect);

    public EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum(
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
    public static EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum(
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
        EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum>
    {
        public override EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedPreviousObject7OptionsWaadProtocolEnum value,
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
        public const string WsFederation = "ws-federation";

        public const string OpenidConnect = "openid-connect";
    }
}
