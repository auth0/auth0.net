using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(AllocationStrategyEnum.AllocationStrategyEnumSerializer))]
[Serializable]
public readonly record struct AllocationStrategyEnum : IStringEnum
{
    public static readonly AllocationStrategyEnum Percentage = new(Values.Percentage);

    public static readonly AllocationStrategyEnum Segment = new(Values.Segment);

    public AllocationStrategyEnum(string value)
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
    public static AllocationStrategyEnum FromCustom(string value)
    {
        return new AllocationStrategyEnum(value);
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

    public static bool operator ==(AllocationStrategyEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AllocationStrategyEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AllocationStrategyEnum value) => value.Value;

    public static explicit operator AllocationStrategyEnum(string value) => new(value);

    internal class AllocationStrategyEnumSerializer : JsonConverter<AllocationStrategyEnum>
    {
        public override AllocationStrategyEnum Read(
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
            return new AllocationStrategyEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AllocationStrategyEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AllocationStrategyEnum ReadAsPropertyName(
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
            return new AllocationStrategyEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AllocationStrategyEnum value,
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
        public const string Percentage = "percentage";

        public const string Segment = "segment";
    }
}
