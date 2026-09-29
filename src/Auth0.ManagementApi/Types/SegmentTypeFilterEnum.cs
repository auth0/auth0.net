using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(SegmentTypeFilterEnum.SegmentTypeFilterEnumSerializer))]
[Serializable]
public readonly record struct SegmentTypeFilterEnum : IStringEnum
{
    public static readonly SegmentTypeFilterEnum Auth0 = new(Values.Auth0);

    public static readonly SegmentTypeFilterEnum Self = new(Values.Self);

    public SegmentTypeFilterEnum(string value)
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
    public static SegmentTypeFilterEnum FromCustom(string value)
    {
        return new SegmentTypeFilterEnum(value);
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

    public static bool operator ==(SegmentTypeFilterEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SegmentTypeFilterEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SegmentTypeFilterEnum value) => value.Value;

    public static explicit operator SegmentTypeFilterEnum(string value) => new(value);

    internal class SegmentTypeFilterEnumSerializer : JsonConverter<SegmentTypeFilterEnum>
    {
        public override SegmentTypeFilterEnum Read(
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
            return new SegmentTypeFilterEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SegmentTypeFilterEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SegmentTypeFilterEnum ReadAsPropertyName(
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
            return new SegmentTypeFilterEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SegmentTypeFilterEnum value,
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
        public const string Auth0 = "auth0";

        public const string Self = "self";
    }
}
