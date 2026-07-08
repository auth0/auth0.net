using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum.EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum Auto =
        new(Values.Auto);

    public static readonly EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum S256 =
        new(Values.S256);

    public static readonly EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum Plain =
        new(Values.Plain);

    public static readonly EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum Disabled =
        new(Values.Disabled);

    public EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum(
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
    public static EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum(
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
        EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum>
    {
        public override EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum Read(
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
            return new EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject0OptionsConnectionSettingsPkceEnum value,
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
