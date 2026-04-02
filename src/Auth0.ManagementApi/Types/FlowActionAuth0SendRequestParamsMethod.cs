using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionAuth0SendRequestParamsMethod.FlowActionAuth0SendRequestParamsMethodSerializer)
)]
[Serializable]
public readonly record struct FlowActionAuth0SendRequestParamsMethod : IStringEnum
{
    public static readonly FlowActionAuth0SendRequestParamsMethod Get = new(Values.Get);

    public static readonly FlowActionAuth0SendRequestParamsMethod Post = new(Values.Post);

    public static readonly FlowActionAuth0SendRequestParamsMethod Put = new(Values.Put);

    public static readonly FlowActionAuth0SendRequestParamsMethod Patch = new(Values.Patch);

    public static readonly FlowActionAuth0SendRequestParamsMethod Delete = new(Values.Delete);

    public FlowActionAuth0SendRequestParamsMethod(string value)
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
    public static FlowActionAuth0SendRequestParamsMethod FromCustom(string value)
    {
        return new FlowActionAuth0SendRequestParamsMethod(value);
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

    public static bool operator ==(FlowActionAuth0SendRequestParamsMethod value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionAuth0SendRequestParamsMethod value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionAuth0SendRequestParamsMethod value) =>
        value.Value;

    public static explicit operator FlowActionAuth0SendRequestParamsMethod(string value) =>
        new(value);

    internal class FlowActionAuth0SendRequestParamsMethodSerializer
        : JsonConverter<FlowActionAuth0SendRequestParamsMethod>
    {
        public override FlowActionAuth0SendRequestParamsMethod Read(
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
            return new FlowActionAuth0SendRequestParamsMethod(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionAuth0SendRequestParamsMethod value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionAuth0SendRequestParamsMethod ReadAsPropertyName(
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
            return new FlowActionAuth0SendRequestParamsMethod(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionAuth0SendRequestParamsMethod value,
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
        public const string Get = "GET";

        public const string Post = "POST";

        public const string Put = "PUT";

        public const string Patch = "PATCH";

        public const string Delete = "DELETE";
    }
}
