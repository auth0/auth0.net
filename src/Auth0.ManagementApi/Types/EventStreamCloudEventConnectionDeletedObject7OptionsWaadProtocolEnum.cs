using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum.EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum WsFederation =
        new(Values.WsFederation);

    public static readonly EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum OpenidConnect =
        new(Values.OpenidConnect);

    public EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum(string value)
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
    public static EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum(value);
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
        EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum>
    {
        public override EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum Read(
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
            return new EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject7OptionsWaadProtocolEnum value,
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
