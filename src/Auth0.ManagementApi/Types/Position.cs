using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(Position.PositionSerializer))]
[Serializable]
public readonly record struct Position : IStringEnum
{
    public static readonly Position Left = new(Values.Left);

    public static readonly Position Center = new(Values.Center);

    public static readonly Position Right = new(Values.Right);

    public Position(string value)
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
    public static Position FromCustom(string value)
    {
        return new Position(value);
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

    public static bool operator ==(Position value1, string value2) => value1.Value.Equals(value2);

    public static bool operator !=(Position value1, string value2) => !value1.Value.Equals(value2);

    public static explicit operator string(Position value) => value.Value;

    public static explicit operator Position(string value) => new(value);

    internal class PositionSerializer : JsonConverter<Position>
    {
        public override Position Read(
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
            return new Position(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Position value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override Position ReadAsPropertyName(
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
            return new Position(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            Position value,
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
        public const string Left = "left";

        public const string Center = "center";

        public const string Right = "right";
    }
}
