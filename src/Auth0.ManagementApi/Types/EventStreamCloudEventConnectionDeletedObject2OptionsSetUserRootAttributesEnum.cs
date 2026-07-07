using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum.EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum OnEachLogin =
        new(Values.OnEachLogin);

    public static readonly EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum OnFirstLogin =
        new(Values.OnFirstLogin);

    public static readonly EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum NeverOnLogin =
        new(Values.NeverOnLogin);

    public EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum(
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
    public static EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum(
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
        EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum>
    {
        public override EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum Read(
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
            return new EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum value,
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
        public const string OnEachLogin = "on_each_login";

        public const string OnFirstLogin = "on_first_login";

        public const string NeverOnLogin = "never_on_login";
    }
}
