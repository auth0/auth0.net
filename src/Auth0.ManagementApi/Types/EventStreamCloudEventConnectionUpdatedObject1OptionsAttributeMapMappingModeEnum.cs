using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum.EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum BasicProfile =
        new(Values.BasicProfile);

    public static readonly EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum UseMap =
        new(Values.UseMap);

    public EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum(
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
    public static EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum(
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
        EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum>
    {
        public override EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum Read(
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
            return new EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject1OptionsAttributeMapMappingModeEnum value,
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
        public const string BasicProfile = "basic_profile";

        public const string UseMap = "use_map";
    }
}
