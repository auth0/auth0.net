using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FormsRequestParametersHydrateEnum.FormsRequestParametersHydrateEnumSerializer)
)]
[Serializable]
public readonly record struct FormsRequestParametersHydrateEnum : IStringEnum
{
    public static readonly FormsRequestParametersHydrateEnum FlowCount = new(Values.FlowCount);

    public static readonly FormsRequestParametersHydrateEnum Links = new(Values.Links);

    public FormsRequestParametersHydrateEnum(string value)
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
    public static FormsRequestParametersHydrateEnum FromCustom(string value)
    {
        return new FormsRequestParametersHydrateEnum(value);
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

    public static bool operator ==(FormsRequestParametersHydrateEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormsRequestParametersHydrateEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormsRequestParametersHydrateEnum value) => value.Value;

    public static explicit operator FormsRequestParametersHydrateEnum(string value) => new(value);

    internal class FormsRequestParametersHydrateEnumSerializer
        : JsonConverter<FormsRequestParametersHydrateEnum>
    {
        public override FormsRequestParametersHydrateEnum Read(
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
            return new FormsRequestParametersHydrateEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormsRequestParametersHydrateEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FormsRequestParametersHydrateEnum ReadAsPropertyName(
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
            return new FormsRequestParametersHydrateEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormsRequestParametersHydrateEnum value,
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
        public const string FlowCount = "flow_count";

        public const string Links = "links";
    }
}
