using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionDeletedObject1StrategyEnum.EventStreamCloudEventConnectionDeletedObject1StrategyEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionDeletedObject1StrategyEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionDeletedObject1StrategyEnum Okta = new(
        Values.Okta
    );

    public EventStreamCloudEventConnectionDeletedObject1StrategyEnum(string value)
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
    public static EventStreamCloudEventConnectionDeletedObject1StrategyEnum FromCustom(string value)
    {
        return new EventStreamCloudEventConnectionDeletedObject1StrategyEnum(value);
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
        EventStreamCloudEventConnectionDeletedObject1StrategyEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionDeletedObject1StrategyEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionDeletedObject1StrategyEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionDeletedObject1StrategyEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionDeletedObject1StrategyEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionDeletedObject1StrategyEnum>
    {
        public override EventStreamCloudEventConnectionDeletedObject1StrategyEnum Read(
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
            return new EventStreamCloudEventConnectionDeletedObject1StrategyEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject1StrategyEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionDeletedObject1StrategyEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionDeletedObject1StrategyEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject1StrategyEnum value,
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
        public const string Okta = "okta";
    }
}
