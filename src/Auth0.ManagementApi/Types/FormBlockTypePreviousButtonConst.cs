using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormBlockTypePreviousButtonConst.FormBlockTypePreviousButtonConstSerializer))]
[Serializable]
public readonly record struct FormBlockTypePreviousButtonConst : IStringEnum
{
    public static readonly FormBlockTypePreviousButtonConst PreviousButton = new(
        Values.PreviousButton
    );

    public FormBlockTypePreviousButtonConst(string value)
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
    public static FormBlockTypePreviousButtonConst FromCustom(string value)
    {
        return new FormBlockTypePreviousButtonConst(value);
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

    public static bool operator ==(FormBlockTypePreviousButtonConst value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormBlockTypePreviousButtonConst value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormBlockTypePreviousButtonConst value) => value.Value;

    public static explicit operator FormBlockTypePreviousButtonConst(string value) => new(value);

    internal class FormBlockTypePreviousButtonConstSerializer
        : JsonConverter<FormBlockTypePreviousButtonConst>
    {
        public override FormBlockTypePreviousButtonConst Read(
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
            return new FormBlockTypePreviousButtonConst(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormBlockTypePreviousButtonConst value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FormBlockTypePreviousButtonConst ReadAsPropertyName(
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
            return new FormBlockTypePreviousButtonConst(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormBlockTypePreviousButtonConst value,
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
        public const string PreviousButton = "PREVIOUS_BUTTON";
    }
}
