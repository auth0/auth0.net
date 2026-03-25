using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormFieldTypeSocialConst.FormFieldTypeSocialConstSerializer))]
[Serializable]
public readonly record struct FormFieldTypeSocialConst : IStringEnum
{
    public static readonly FormFieldTypeSocialConst Social = new(Values.Social);

    public FormFieldTypeSocialConst(string value)
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
    public static FormFieldTypeSocialConst FromCustom(string value)
    {
        return new FormFieldTypeSocialConst(value);
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

    public static bool operator ==(FormFieldTypeSocialConst value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormFieldTypeSocialConst value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormFieldTypeSocialConst value) => value.Value;

    public static explicit operator FormFieldTypeSocialConst(string value) => new(value);

    internal class FormFieldTypeSocialConstSerializer : JsonConverter<FormFieldTypeSocialConst>
    {
        public override FormFieldTypeSocialConst Read(
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
            return new FormFieldTypeSocialConst(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormFieldTypeSocialConst value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FormFieldTypeSocialConst ReadAsPropertyName(
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
            return new FormFieldTypeSocialConst(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormFieldTypeSocialConst value,
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
        public const string Social = "SOCIAL";
    }
}
