using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(CreateConnectionRequestContentPingFederateStrategy.CreateConnectionRequestContentPingFederateStrategySerializer)
)]
[Serializable]
public readonly record struct CreateConnectionRequestContentPingFederateStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentPingFederateStrategy Pingfederate = new(
        Values.Pingfederate
    );

    public CreateConnectionRequestContentPingFederateStrategy(string value)
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
    public static CreateConnectionRequestContentPingFederateStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentPingFederateStrategy(value);
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
        CreateConnectionRequestContentPingFederateStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentPingFederateStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateConnectionRequestContentPingFederateStrategy value
    ) => value.Value;

    public static explicit operator CreateConnectionRequestContentPingFederateStrategy(
        string value
    ) => new(value);

    internal class CreateConnectionRequestContentPingFederateStrategySerializer
        : JsonConverter<CreateConnectionRequestContentPingFederateStrategy>
    {
        public override CreateConnectionRequestContentPingFederateStrategy Read(
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
            return new CreateConnectionRequestContentPingFederateStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateConnectionRequestContentPingFederateStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateConnectionRequestContentPingFederateStrategy ReadAsPropertyName(
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
            return new CreateConnectionRequestContentPingFederateStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateConnectionRequestContentPingFederateStrategy value,
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
        public const string Pingfederate = "pingfederate";
    }
}
