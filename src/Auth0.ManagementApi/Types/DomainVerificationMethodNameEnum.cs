using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(DomainVerificationMethodNameEnum.DomainVerificationMethodNameEnumSerializer))]
[Serializable]
public readonly record struct DomainVerificationMethodNameEnum : IStringEnum
{
    public static readonly DomainVerificationMethodNameEnum Cname = new(Values.Cname);

    public static readonly DomainVerificationMethodNameEnum Txt = new(Values.Txt);

    public DomainVerificationMethodNameEnum(string value)
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
    public static DomainVerificationMethodNameEnum FromCustom(string value)
    {
        return new DomainVerificationMethodNameEnum(value);
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

    public static bool operator ==(DomainVerificationMethodNameEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DomainVerificationMethodNameEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DomainVerificationMethodNameEnum value) => value.Value;

    public static explicit operator DomainVerificationMethodNameEnum(string value) => new(value);

    internal class DomainVerificationMethodNameEnumSerializer
        : JsonConverter<DomainVerificationMethodNameEnum>
    {
        public override DomainVerificationMethodNameEnum Read(
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
            return new DomainVerificationMethodNameEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DomainVerificationMethodNameEnum value,
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
        public const string Cname = "cname";

        public const string Txt = "txt";
    }
}
