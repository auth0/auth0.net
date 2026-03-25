using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(CreateConnectionRequestContentWindowsLiveStrategy.CreateConnectionRequestContentWindowsLiveStrategySerializer)
)]
[Serializable]
public readonly record struct CreateConnectionRequestContentWindowsLiveStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentWindowsLiveStrategy Windowslive = new(
        Values.Windowslive
    );

    public CreateConnectionRequestContentWindowsLiveStrategy(string value)
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
    public static CreateConnectionRequestContentWindowsLiveStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentWindowsLiveStrategy(value);
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
        CreateConnectionRequestContentWindowsLiveStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentWindowsLiveStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateConnectionRequestContentWindowsLiveStrategy value
    ) => value.Value;

    public static explicit operator CreateConnectionRequestContentWindowsLiveStrategy(
        string value
    ) => new(value);

    internal class CreateConnectionRequestContentWindowsLiveStrategySerializer
        : JsonConverter<CreateConnectionRequestContentWindowsLiveStrategy>
    {
        public override CreateConnectionRequestContentWindowsLiveStrategy Read(
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
            return new CreateConnectionRequestContentWindowsLiveStrategy(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateConnectionRequestContentWindowsLiveStrategy value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CreateConnectionRequestContentWindowsLiveStrategy ReadAsPropertyName(
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
            return new CreateConnectionRequestContentWindowsLiveStrategy(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateConnectionRequestContentWindowsLiveStrategy value,
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
        public const string Windowslive = "windowslive";
    }
}
