using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(GetFlowRequestParametersHydrateEnum.GetFlowRequestParametersHydrateEnumSerializer)
)]
[Serializable]
public readonly record struct GetFlowRequestParametersHydrateEnum : IStringEnum
{
    public static readonly GetFlowRequestParametersHydrateEnum FormCount = new(Values.FormCount);

    public static readonly GetFlowRequestParametersHydrateEnum Forms = new(Values.Forms);

    public GetFlowRequestParametersHydrateEnum(string value)
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
    public static GetFlowRequestParametersHydrateEnum FromCustom(string value)
    {
        return new GetFlowRequestParametersHydrateEnum(value);
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

    public static bool operator ==(GetFlowRequestParametersHydrateEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GetFlowRequestParametersHydrateEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GetFlowRequestParametersHydrateEnum value) =>
        value.Value;

    public static explicit operator GetFlowRequestParametersHydrateEnum(string value) => new(value);

    internal class GetFlowRequestParametersHydrateEnumSerializer
        : JsonConverter<GetFlowRequestParametersHydrateEnum>
    {
        public override GetFlowRequestParametersHydrateEnum Read(
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
            return new GetFlowRequestParametersHydrateEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetFlowRequestParametersHydrateEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override GetFlowRequestParametersHydrateEnum ReadAsPropertyName(
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
            return new GetFlowRequestParametersHydrateEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetFlowRequestParametersHydrateEnum value,
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
        public const string FormCount = "form_count";

        public const string Forms = "forms";
    }
}
