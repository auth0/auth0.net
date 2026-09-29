using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(SegmentTypeEnum.SegmentTypeEnumSerializer))]
[Serializable]
public readonly record struct SegmentTypeEnum : IStringEnum
{
    public static readonly SegmentTypeEnum Self = new(Values.Self);

    public static readonly SegmentTypeEnum Auth0 = new(Values.Auth0);

    public SegmentTypeEnum(string value)
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
    public static SegmentTypeEnum FromCustom(string value)
    {
        return new SegmentTypeEnum(value);
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

    public static bool operator ==(SegmentTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SegmentTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SegmentTypeEnum value) => value.Value;

    public static explicit operator SegmentTypeEnum(string value) => new(value);

    internal class SegmentTypeEnumSerializer : JsonConverter<SegmentTypeEnum>
    {
        public override SegmentTypeEnum Read(
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
            return new SegmentTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SegmentTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SegmentTypeEnum ReadAsPropertyName(
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
            return new SegmentTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SegmentTypeEnum value,
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
        public const string Self = "self";

        public const string Auth0 = "auth0";
    }
}
