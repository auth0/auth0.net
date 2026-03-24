using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(CustomDomainCustomClientIpHeaderEnum.CustomDomainCustomClientIpHeaderEnumSerializer)
)]
[Serializable]
public readonly record struct CustomDomainCustomClientIpHeaderEnum : IStringEnum
{
    public static readonly CustomDomainCustomClientIpHeaderEnum TrueClientIp = new(
        Values.TrueClientIp
    );

    public static readonly CustomDomainCustomClientIpHeaderEnum CfConnectingIp = new(
        Values.CfConnectingIp
    );

    public static readonly CustomDomainCustomClientIpHeaderEnum XForwardedFor = new(
        Values.XForwardedFor
    );

    public static readonly CustomDomainCustomClientIpHeaderEnum XAzureClientip = new(
        Values.XAzureClientip
    );

    public static readonly CustomDomainCustomClientIpHeaderEnum Empty = new(Values.Empty);

    public CustomDomainCustomClientIpHeaderEnum(string value)
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
    public static CustomDomainCustomClientIpHeaderEnum FromCustom(string value)
    {
        return new CustomDomainCustomClientIpHeaderEnum(value);
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

    public static bool operator ==(CustomDomainCustomClientIpHeaderEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomDomainCustomClientIpHeaderEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomDomainCustomClientIpHeaderEnum value) =>
        value.Value;

    public static explicit operator CustomDomainCustomClientIpHeaderEnum(string value) =>
        new(value);

    internal class CustomDomainCustomClientIpHeaderEnumSerializer
        : JsonConverter<CustomDomainCustomClientIpHeaderEnum>
    {
        public override CustomDomainCustomClientIpHeaderEnum Read(
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
            return new CustomDomainCustomClientIpHeaderEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CustomDomainCustomClientIpHeaderEnum value,
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
        public const string TrueClientIp = "true-client-ip";

        public const string CfConnectingIp = "cf-connecting-ip";

        public const string XForwardedFor = "x-forwarded-for";

        public const string XAzureClientip = "x-azure-clientip";

        public const string Empty = "";
    }
}
