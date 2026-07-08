using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(OrganizationThirdPartyClientAccessEnum.OrganizationThirdPartyClientAccessEnumSerializer)
)]
[Serializable]
public readonly record struct OrganizationThirdPartyClientAccessEnum : IStringEnum
{
    public static readonly OrganizationThirdPartyClientAccessEnum Block = new(Values.Block);

    public static readonly OrganizationThirdPartyClientAccessEnum Allow = new(Values.Allow);

    public OrganizationThirdPartyClientAccessEnum(string value)
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
    public static OrganizationThirdPartyClientAccessEnum FromCustom(string value)
    {
        return new OrganizationThirdPartyClientAccessEnum(value);
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

    public static bool operator ==(OrganizationThirdPartyClientAccessEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrganizationThirdPartyClientAccessEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrganizationThirdPartyClientAccessEnum value) =>
        value.Value;

    public static explicit operator OrganizationThirdPartyClientAccessEnum(string value) =>
        new(value);

    internal class OrganizationThirdPartyClientAccessEnumSerializer
        : JsonConverter<OrganizationThirdPartyClientAccessEnum>
    {
        public override OrganizationThirdPartyClientAccessEnum Read(
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
            return new OrganizationThirdPartyClientAccessEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrganizationThirdPartyClientAccessEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrganizationThirdPartyClientAccessEnum ReadAsPropertyName(
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
            return new OrganizationThirdPartyClientAccessEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrganizationThirdPartyClientAccessEnum value,
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
        public const string Block = "block";

        public const string Allow = "allow";
    }
}
