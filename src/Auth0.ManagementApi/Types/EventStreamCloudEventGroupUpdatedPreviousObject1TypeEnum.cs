using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnum.EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnum : IStringEnum
{
    public static readonly EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnum Organization =
        new(Values.Organization);

    public EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnum(string value)
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
    public static EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnum FromCustom(string value)
    {
        return new EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnum(value);
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
        EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnumSerializer
        : JsonConverter<EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnum>
    {
        public override EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnum Read(
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
            return new EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupUpdatedPreviousObject1TypeEnum value,
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
        public const string Organization = "organization";
    }
}
