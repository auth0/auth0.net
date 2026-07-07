using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum.EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum OnEachLogin =
        new(Values.OnEachLogin);

    public static readonly EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum OnFirstLogin =
        new(Values.OnFirstLogin);

    public static readonly EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum NeverOnLogin =
        new(Values.NeverOnLogin);

    public EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum(
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
    public static EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum(
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
        EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum value,
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
