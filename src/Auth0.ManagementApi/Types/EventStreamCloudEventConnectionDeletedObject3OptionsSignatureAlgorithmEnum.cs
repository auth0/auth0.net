using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum.EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum RsaSha1 =
        new(Values.RsaSha1);

    public static readonly EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum RsaSha256 =
        new(Values.RsaSha256);

    public EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum(string value)
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
    public static EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum(
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
        EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnumSerializer
        : JsonConverter<EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum>
    {
        public override EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum Read(
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
            return new EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventConnectionDeletedObject3OptionsSignatureAlgorithmEnum value,
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
        public const string RsaSha1 = "rsa-sha1";

        public const string RsaSha256 = "rsa-sha256";
    }
}
