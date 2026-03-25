using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(RefreshTokenRotationTypeEnum.RefreshTokenRotationTypeEnumSerializer))]
[Serializable]
public readonly record struct RefreshTokenRotationTypeEnum : IStringEnum
{
    public static readonly RefreshTokenRotationTypeEnum Rotating = new(Values.Rotating);

    public static readonly RefreshTokenRotationTypeEnum NonRotating = new(Values.NonRotating);

    public RefreshTokenRotationTypeEnum(string value)
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
    public static RefreshTokenRotationTypeEnum FromCustom(string value)
    {
        return new RefreshTokenRotationTypeEnum(value);
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

    public static bool operator ==(RefreshTokenRotationTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RefreshTokenRotationTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RefreshTokenRotationTypeEnum value) => value.Value;

    public static explicit operator RefreshTokenRotationTypeEnum(string value) => new(value);

    internal class RefreshTokenRotationTypeEnumSerializer
        : JsonConverter<RefreshTokenRotationTypeEnum>
    {
        public override RefreshTokenRotationTypeEnum Read(
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
            return new RefreshTokenRotationTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            RefreshTokenRotationTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override RefreshTokenRotationTypeEnum ReadAsPropertyName(
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
            return new RefreshTokenRotationTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RefreshTokenRotationTypeEnum value,
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
        public const string Rotating = "rotating";

        public const string NonRotating = "non-rotating";
    }
}
