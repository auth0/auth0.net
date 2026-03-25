using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormComponentCategoryFieldConst.FormComponentCategoryFieldConstSerializer))]
[Serializable]
public readonly record struct FormComponentCategoryFieldConst : IStringEnum
{
    public static readonly FormComponentCategoryFieldConst Field = new(Values.Field);

    public FormComponentCategoryFieldConst(string value)
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
    public static FormComponentCategoryFieldConst FromCustom(string value)
    {
        return new FormComponentCategoryFieldConst(value);
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

    public static bool operator ==(FormComponentCategoryFieldConst value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormComponentCategoryFieldConst value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormComponentCategoryFieldConst value) => value.Value;

    public static explicit operator FormComponentCategoryFieldConst(string value) => new(value);

    internal class FormComponentCategoryFieldConstSerializer
        : JsonConverter<FormComponentCategoryFieldConst>
    {
        public override FormComponentCategoryFieldConst Read(
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
            return new FormComponentCategoryFieldConst(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormComponentCategoryFieldConst value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FormComponentCategoryFieldConst ReadAsPropertyName(
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
            return new FormComponentCategoryFieldConst(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormComponentCategoryFieldConst value,
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
        public const string Field = "FIELD";
    }
}
