using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(DomainVerificationStatusEnum.DomainVerificationStatusEnumSerializer))]
[Serializable]
public readonly record struct DomainVerificationStatusEnum : IStringEnum
{
    public static readonly DomainVerificationStatusEnum Verified = new(Values.Verified);

    public static readonly DomainVerificationStatusEnum Pending = new(Values.Pending);

    public static readonly DomainVerificationStatusEnum Failed = new(Values.Failed);

    public DomainVerificationStatusEnum(string value)
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
    public static DomainVerificationStatusEnum FromCustom(string value)
    {
        return new DomainVerificationStatusEnum(value);
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

    public static bool operator ==(DomainVerificationStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DomainVerificationStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DomainVerificationStatusEnum value) => value.Value;

    public static explicit operator DomainVerificationStatusEnum(string value) => new(value);

    internal class DomainVerificationStatusEnumSerializer
        : JsonConverter<DomainVerificationStatusEnum>
    {
        public override DomainVerificationStatusEnum Read(
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
            return new DomainVerificationStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DomainVerificationStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DomainVerificationStatusEnum ReadAsPropertyName(
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
            return new DomainVerificationStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DomainVerificationStatusEnum value,
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
        public const string Verified = "verified";

        public const string Pending = "pending";

        public const string Failed = "failed";
    }
}
