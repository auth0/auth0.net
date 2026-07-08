using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum.EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum Auto =
        new(Values.Auto);

    public static readonly EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum S256 =
        new(Values.S256);

    public static readonly EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum Plain =
        new(Values.Plain);

    public static readonly EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum Disabled =
        new(Values.Disabled);

    public EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum(
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
    public static EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum(
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
        EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum>
    {
        public override EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum Read(
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
            return new EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject1OptionsConnectionSettingsPkceEnum value,
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
