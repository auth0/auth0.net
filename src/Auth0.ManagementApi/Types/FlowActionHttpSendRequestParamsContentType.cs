using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionHttpSendRequestParamsContentType.FlowActionHttpSendRequestParamsContentTypeSerializer)
)]
[Serializable]
public readonly record struct FlowActionHttpSendRequestParamsContentType : IStringEnum
{
    public static readonly FlowActionHttpSendRequestParamsContentType Json = new(Values.Json);

    public static readonly FlowActionHttpSendRequestParamsContentType Form = new(Values.Form);

    public static readonly FlowActionHttpSendRequestParamsContentType Xml = new(Values.Xml);

    public FlowActionHttpSendRequestParamsContentType(string value)
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
    public static FlowActionHttpSendRequestParamsContentType FromCustom(string value)
    {
        return new FlowActionHttpSendRequestParamsContentType(value);
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
        FlowActionHttpSendRequestParamsContentType value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowActionHttpSendRequestParamsContentType value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionHttpSendRequestParamsContentType value) =>
        value.Value;

    public static explicit operator FlowActionHttpSendRequestParamsContentType(string value) =>
        new(value);

    internal class FlowActionHttpSendRequestParamsContentTypeSerializer
        : JsonConverter<FlowActionHttpSendRequestParamsContentType>
    {
        public override FlowActionHttpSendRequestParamsContentType Read(
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
            return new FlowActionHttpSendRequestParamsContentType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionHttpSendRequestParamsContentType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionHttpSendRequestParamsContentType ReadAsPropertyName(
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
            return new FlowActionHttpSendRequestParamsContentType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionHttpSendRequestParamsContentType value,
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
        public const string Json = "JSON";

        public const string Form = "FORM";

        public const string Xml = "XML";
    }
}
