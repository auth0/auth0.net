using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionJwtDecodeJwtAction.FlowActionJwtDecodeJwtActionSerializer))]
[Serializable]
public readonly record struct FlowActionJwtDecodeJwtAction : IStringEnum
{
    public static readonly FlowActionJwtDecodeJwtAction DecodeJwt = new(Values.DecodeJwt);

    public FlowActionJwtDecodeJwtAction(string value)
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
    public static FlowActionJwtDecodeJwtAction FromCustom(string value)
    {
        return new FlowActionJwtDecodeJwtAction(value);
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

    public static bool operator ==(FlowActionJwtDecodeJwtAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionJwtDecodeJwtAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionJwtDecodeJwtAction value) => value.Value;

    public static explicit operator FlowActionJwtDecodeJwtAction(string value) => new(value);

    internal class FlowActionJwtDecodeJwtActionSerializer
        : JsonConverter<FlowActionJwtDecodeJwtAction>
    {
        public override FlowActionJwtDecodeJwtAction Read(
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
            return new FlowActionJwtDecodeJwtAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionJwtDecodeJwtAction value,
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
        public const string DecodeJwt = "DECODE_JWT";
    }
}
