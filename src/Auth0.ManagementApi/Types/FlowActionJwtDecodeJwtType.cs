using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionJwtDecodeJwtType.FlowActionJwtDecodeJwtTypeSerializer))]
[Serializable]
public readonly record struct FlowActionJwtDecodeJwtType : IStringEnum
{
    public static readonly FlowActionJwtDecodeJwtType Jwt = new(Values.Jwt);

    public FlowActionJwtDecodeJwtType(string value)
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
    public static FlowActionJwtDecodeJwtType FromCustom(string value)
    {
        return new FlowActionJwtDecodeJwtType(value);
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

    public static bool operator ==(FlowActionJwtDecodeJwtType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionJwtDecodeJwtType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionJwtDecodeJwtType value) => value.Value;

    public static explicit operator FlowActionJwtDecodeJwtType(string value) => new(value);

    internal class FlowActionJwtDecodeJwtTypeSerializer : JsonConverter<FlowActionJwtDecodeJwtType>
    {
        public override FlowActionJwtDecodeJwtType Read(
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
            return new FlowActionJwtDecodeJwtType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionJwtDecodeJwtType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Jwt = "JWT";
    }
}
