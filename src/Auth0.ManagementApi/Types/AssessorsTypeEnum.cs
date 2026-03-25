using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(AssessorsTypeEnum.AssessorsTypeEnumSerializer))]
[Serializable]
public readonly record struct AssessorsTypeEnum : IStringEnum
{
    public static readonly AssessorsTypeEnum NewDevice = new(Values.NewDevice);

    public AssessorsTypeEnum(string value)
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
    public static AssessorsTypeEnum FromCustom(string value)
    {
        return new AssessorsTypeEnum(value);
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

    public static bool operator ==(AssessorsTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AssessorsTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AssessorsTypeEnum value) => value.Value;

    public static explicit operator AssessorsTypeEnum(string value) => new(value);

    internal class AssessorsTypeEnumSerializer : JsonConverter<AssessorsTypeEnum>
    {
        public override AssessorsTypeEnum Read(
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
            return new AssessorsTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AssessorsTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AssessorsTypeEnum ReadAsPropertyName(
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
            return new AssessorsTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AssessorsTypeEnum value,
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
        public const string NewDevice = "new-device";
    }
}
