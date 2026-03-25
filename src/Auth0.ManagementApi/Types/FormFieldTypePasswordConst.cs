using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormFieldTypePasswordConst.FormFieldTypePasswordConstSerializer))]
[Serializable]
public readonly record struct FormFieldTypePasswordConst : IStringEnum
{
    public static readonly FormFieldTypePasswordConst Password = new(Values.Password);

    public FormFieldTypePasswordConst(string value)
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
    public static FormFieldTypePasswordConst FromCustom(string value)
    {
        return new FormFieldTypePasswordConst(value);
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

    public static bool operator ==(FormFieldTypePasswordConst value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormFieldTypePasswordConst value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormFieldTypePasswordConst value) => value.Value;

    public static explicit operator FormFieldTypePasswordConst(string value) => new(value);

    internal class FormFieldTypePasswordConstSerializer : JsonConverter<FormFieldTypePasswordConst>
    {
        public override FormFieldTypePasswordConst Read(
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
            return new FormFieldTypePasswordConst(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormFieldTypePasswordConst value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FormFieldTypePasswordConst ReadAsPropertyName(
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
            return new FormFieldTypePasswordConst(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormFieldTypePasswordConst value,
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
        public const string Password = "PASSWORD";
    }
}
