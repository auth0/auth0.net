using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject6StrategyEnum.EventStreamCloudEventConnectionCreatedObject6StrategyEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject6StrategyEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject6StrategyEnum GoogleApps =
        new(Values.GoogleApps);

    public EventStreamCloudEventConnectionCreatedObject6StrategyEnum(string value)
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
    public static EventStreamCloudEventConnectionCreatedObject6StrategyEnum FromCustom(string value)
    {
        return new EventStreamCloudEventConnectionCreatedObject6StrategyEnum(value);
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
        EventStreamCloudEventConnectionCreatedObject6StrategyEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject6StrategyEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject6StrategyEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject6StrategyEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject6StrategyEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject6StrategyEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject6StrategyEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedObject6StrategyEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject6StrategyEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject6StrategyEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedObject6StrategyEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject6StrategyEnum value,
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
        public const string GoogleApps = "google-apps";
    }
}
