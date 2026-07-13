using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum.EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum Auto =
        new(Values.Auto);

    public static readonly EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum S256 =
        new(Values.S256);

    public static readonly EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum Plain =
        new(Values.Plain);

    public static readonly EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum Disabled =
        new(Values.Disabled);

    public EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum(
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
    public static EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum(
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
        EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject1OptionsConnectionSettingsPkceEnum value,
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
