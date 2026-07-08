using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum.EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum Auto =
        new(Values.Auto);

    public static readonly EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum S256 =
        new(Values.S256);

    public static readonly EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum Plain =
        new(Values.Plain);

    public static readonly EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum Disabled =
        new(Values.Disabled);

    public EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum(
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
    public static EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum(
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
        EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum>
    {
        public override EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum Read(
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
            return new EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionUpdatedObject0OptionsConnectionSettingsPkceEnum value,
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
        public const string Auto = "auto";

        public const string S256 = "S256";

        public const string Plain = "plain";

        public const string Disabled = "disabled";
    }
}
