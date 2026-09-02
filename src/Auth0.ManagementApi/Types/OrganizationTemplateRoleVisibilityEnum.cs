using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(OrganizationTemplateRoleVisibilityEnum.OrganizationTemplateRoleVisibilityEnumSerializer)
)]
[Serializable]
public readonly record struct OrganizationTemplateRoleVisibilityEnum : IStringEnum
{
    public static readonly OrganizationTemplateRoleVisibilityEnum Write = new(Values.Write);

    public static readonly OrganizationTemplateRoleVisibilityEnum ReadOnly = new(Values.ReadOnly);

    public static readonly OrganizationTemplateRoleVisibilityEnum Hidden = new(Values.Hidden);

    public OrganizationTemplateRoleVisibilityEnum(string value)
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
    public static OrganizationTemplateRoleVisibilityEnum FromCustom(string value)
    {
        return new OrganizationTemplateRoleVisibilityEnum(value);
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

    public static bool operator ==(OrganizationTemplateRoleVisibilityEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrganizationTemplateRoleVisibilityEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrganizationTemplateRoleVisibilityEnum value) =>
        value.Value;

    public static explicit operator OrganizationTemplateRoleVisibilityEnum(string value) =>
        new(value);

    internal class OrganizationTemplateRoleVisibilityEnumSerializer
        : JsonConverter<OrganizationTemplateRoleVisibilityEnum>
    {
        public override OrganizationTemplateRoleVisibilityEnum Read(
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
            return new OrganizationTemplateRoleVisibilityEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrganizationTemplateRoleVisibilityEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrganizationTemplateRoleVisibilityEnum ReadAsPropertyName(
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
            return new OrganizationTemplateRoleVisibilityEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrganizationTemplateRoleVisibilityEnum value,
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
        public const string Write = "write";

        public const string ReadOnly = "read_only";

        public const string Hidden = "hidden";
    }
}
