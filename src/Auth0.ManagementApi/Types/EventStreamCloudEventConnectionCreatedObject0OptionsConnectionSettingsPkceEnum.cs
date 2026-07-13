using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum.EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum Auto =
        new(Values.Auto);

    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum S256 =
        new(Values.S256);

    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum Plain =
        new(Values.Plain);

    public static readonly EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum Disabled =
        new(Values.Disabled);

    public EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum(
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
    public static EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum(
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
        EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject0OptionsConnectionSettingsPkceEnum value,
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
