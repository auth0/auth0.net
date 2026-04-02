using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(PasswordDefaultDictionariesEnum.PasswordDefaultDictionariesEnumSerializer))]
[Serializable]
public readonly record struct PasswordDefaultDictionariesEnum : IStringEnum
{
    public static readonly PasswordDefaultDictionariesEnum En10K = new(Values.En10K);

    public static readonly PasswordDefaultDictionariesEnum En100K = new(Values.En100K);

    public PasswordDefaultDictionariesEnum(string value)
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
    public static PasswordDefaultDictionariesEnum FromCustom(string value)
    {
        return new PasswordDefaultDictionariesEnum(value);
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

    public static bool operator ==(PasswordDefaultDictionariesEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PasswordDefaultDictionariesEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PasswordDefaultDictionariesEnum value) => value.Value;

    public static explicit operator PasswordDefaultDictionariesEnum(string value) => new(value);

    internal class PasswordDefaultDictionariesEnumSerializer
        : JsonConverter<PasswordDefaultDictionariesEnum>
    {
        public override PasswordDefaultDictionariesEnum Read(
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
            return new PasswordDefaultDictionariesEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PasswordDefaultDictionariesEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override PasswordDefaultDictionariesEnum ReadAsPropertyName(
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
            return new PasswordDefaultDictionariesEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PasswordDefaultDictionariesEnum value,
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
        public const string En10K = "en_10k";

        public const string En100K = "en_100k";
    }
}
