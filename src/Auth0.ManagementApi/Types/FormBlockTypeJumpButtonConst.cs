using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormBlockTypeJumpButtonConst.FormBlockTypeJumpButtonConstSerializer))]
[Serializable]
public readonly record struct FormBlockTypeJumpButtonConst : IStringEnum
{
    public static readonly FormBlockTypeJumpButtonConst JumpButton = new(Values.JumpButton);

    public FormBlockTypeJumpButtonConst(string value)
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
    public static FormBlockTypeJumpButtonConst FromCustom(string value)
    {
        return new FormBlockTypeJumpButtonConst(value);
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

    public static bool operator ==(FormBlockTypeJumpButtonConst value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormBlockTypeJumpButtonConst value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormBlockTypeJumpButtonConst value) => value.Value;

    public static explicit operator FormBlockTypeJumpButtonConst(string value) => new(value);

    internal class FormBlockTypeJumpButtonConstSerializer
        : JsonConverter<FormBlockTypeJumpButtonConst>
    {
        public override FormBlockTypeJumpButtonConst Read(
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
            return new FormBlockTypeJumpButtonConst(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormBlockTypeJumpButtonConst value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FormBlockTypeJumpButtonConst ReadAsPropertyName(
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
            return new FormBlockTypeJumpButtonConst(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormBlockTypeJumpButtonConst value,
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
        public const string JumpButton = "JUMP_BUTTON";
    }
}
