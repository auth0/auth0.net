using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum.EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum BindAll =
        new(Values.BindAll);

    public static readonly EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum UseMap =
        new(Values.UseMap);

    public EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum(
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
    public static EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum(
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
        EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum>
    {
        public override EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum Read(
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
            return new EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject0OptionsAttributeMapMappingModeEnum value,
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
        public const string BindAll = "bind_all";

        public const string UseMap = "use_map";
    }
}
