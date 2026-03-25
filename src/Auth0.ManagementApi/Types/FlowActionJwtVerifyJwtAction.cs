using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionJwtVerifyJwtAction.FlowActionJwtVerifyJwtActionSerializer))]
[Serializable]
public readonly record struct FlowActionJwtVerifyJwtAction : IStringEnum
{
    public static readonly FlowActionJwtVerifyJwtAction VerifyJwt = new(Values.VerifyJwt);

    public FlowActionJwtVerifyJwtAction(string value)
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
    public static FlowActionJwtVerifyJwtAction FromCustom(string value)
    {
        return new FlowActionJwtVerifyJwtAction(value);
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

    public static bool operator ==(FlowActionJwtVerifyJwtAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionJwtVerifyJwtAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionJwtVerifyJwtAction value) => value.Value;

    public static explicit operator FlowActionJwtVerifyJwtAction(string value) => new(value);

    internal class FlowActionJwtVerifyJwtActionSerializer
        : JsonConverter<FlowActionJwtVerifyJwtAction>
    {
        public override FlowActionJwtVerifyJwtAction Read(
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
            return new FlowActionJwtVerifyJwtAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionJwtVerifyJwtAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionJwtVerifyJwtAction ReadAsPropertyName(
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
            return new FlowActionJwtVerifyJwtAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionJwtVerifyJwtAction value,
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
        public const string VerifyJwt = "VERIFY_JWT";
    }
}
