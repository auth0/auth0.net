using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(OrganizationUsageEnum.OrganizationUsageEnumSerializer))]
[Serializable]
public readonly record struct OrganizationUsageEnum : IStringEnum
{
    public static readonly OrganizationUsageEnum Deny = new(Values.Deny);

    public static readonly OrganizationUsageEnum Allow = new(Values.Allow);

    public static readonly OrganizationUsageEnum Require = new(Values.Require);

    public OrganizationUsageEnum(string value)
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
    public static OrganizationUsageEnum FromCustom(string value)
    {
        return new OrganizationUsageEnum(value);
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

    public static bool operator ==(OrganizationUsageEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrganizationUsageEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrganizationUsageEnum value) => value.Value;

    public static explicit operator OrganizationUsageEnum(string value) => new(value);

    internal class OrganizationUsageEnumSerializer : JsonConverter<OrganizationUsageEnum>
    {
        public override OrganizationUsageEnum Read(
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
            return new OrganizationUsageEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrganizationUsageEnum value,
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
        public const string Deny = "deny";

        public const string Allow = "allow";

        public const string Require = "require";
    }
}
