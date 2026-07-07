using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum.EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum OnEachLogin =
        new(Values.OnEachLogin);

    public static readonly EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum OnFirstLogin =
        new(Values.OnFirstLogin);

    public static readonly EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum NeverOnLogin =
        new(Values.NeverOnLogin);

    public EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum(
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
    public static EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum(
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
        EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum>
    {
        public override EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum Read(
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
            return new EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject6OptionsSetUserRootAttributesEnum value,
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
