using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum.EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum Es256 =
        new(Values.Es256);

    public static readonly EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum Es384 =
        new(Values.Es384);

    public static readonly EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum Es512 =
        new(Values.Es512);

    public static readonly EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum Ed25519 =
        new(Values.Ed25519);

    public EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum(string value)
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
    public static EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum(value);
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
        EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum>
    {
        public override EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum Read(
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
            return new EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionCreatedObject1OptionsDpopSigningAlgEnum value,
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
        public const string Es256 = "ES256";

        public const string Es384 = "ES384";

        public const string Es512 = "ES512";

        public const string Ed25519 = "Ed25519";
    }
}
