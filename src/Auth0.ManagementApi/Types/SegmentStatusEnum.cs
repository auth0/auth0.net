using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(SegmentStatusEnum.SegmentStatusEnumSerializer))]
[Serializable]
public readonly record struct SegmentStatusEnum : IStringEnum
{
    public static readonly SegmentStatusEnum Active = new(Values.Active);

    public static readonly SegmentStatusEnum Archived = new(Values.Archived);

    public SegmentStatusEnum(string value)
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
    public static SegmentStatusEnum FromCustom(string value)
    {
        return new SegmentStatusEnum(value);
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

    public static bool operator ==(SegmentStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SegmentStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SegmentStatusEnum value) => value.Value;

    public static explicit operator SegmentStatusEnum(string value) => new(value);

    internal class SegmentStatusEnumSerializer : JsonConverter<SegmentStatusEnum>
    {
        public override SegmentStatusEnum Read(
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
            return new SegmentStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SegmentStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SegmentStatusEnum ReadAsPropertyName(
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
            return new SegmentStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SegmentStatusEnum value,
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
        public const string Active = "active";

        public const string Archived = "archived";
    }
}
