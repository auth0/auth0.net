using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventContextTransactionResponseTypeItemEnum.EventStreamCloudEventContextTransactionResponseTypeItemEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventContextTransactionResponseTypeItemEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventContextTransactionResponseTypeItemEnum Code = new(
        Values.Code
    );

    public static readonly EventStreamCloudEventContextTransactionResponseTypeItemEnum Token = new(
        Values.Token
    );

    public static readonly EventStreamCloudEventContextTransactionResponseTypeItemEnum IdToken =
        new(Values.IdToken);

    public EventStreamCloudEventContextTransactionResponseTypeItemEnum(string value)
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
    public static EventStreamCloudEventContextTransactionResponseTypeItemEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventContextTransactionResponseTypeItemEnum(value);
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
        EventStreamCloudEventContextTransactionResponseTypeItemEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventContextTransactionResponseTypeItemEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventContextTransactionResponseTypeItemEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventContextTransactionResponseTypeItemEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventContextTransactionResponseTypeItemEnumSerializer
        : JsonConverter<EventStreamCloudEventContextTransactionResponseTypeItemEnum>
    {
        public override EventStreamCloudEventContextTransactionResponseTypeItemEnum Read(
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
            return new EventStreamCloudEventContextTransactionResponseTypeItemEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventContextTransactionResponseTypeItemEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventContextTransactionResponseTypeItemEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventContextTransactionResponseTypeItemEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventContextTransactionResponseTypeItemEnum value,
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
        public const string Code = "code";

        public const string Token = "token";

        public const string IdToken = "id_token";
    }
}
