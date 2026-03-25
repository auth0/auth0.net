using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormNodeTypeStepConst.FormNodeTypeStepConstSerializer))]
[Serializable]
public readonly record struct FormNodeTypeStepConst : IStringEnum
{
    public static readonly FormNodeTypeStepConst Step = new(Values.Step);

    public FormNodeTypeStepConst(string value)
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
    public static FormNodeTypeStepConst FromCustom(string value)
    {
        return new FormNodeTypeStepConst(value);
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

    public static bool operator ==(FormNodeTypeStepConst value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormNodeTypeStepConst value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormNodeTypeStepConst value) => value.Value;

    public static explicit operator FormNodeTypeStepConst(string value) => new(value);

    internal class FormNodeTypeStepConstSerializer : JsonConverter<FormNodeTypeStepConst>
    {
        public override FormNodeTypeStepConst Read(
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
            return new FormNodeTypeStepConst(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormNodeTypeStepConst value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Step = "STEP";
    }
}
