using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(OrganizationTemplateAllowedStrategyEnum.OrganizationTemplateAllowedStrategyEnumSerializer)
)]
[Serializable]
public readonly record struct OrganizationTemplateAllowedStrategyEnum : IStringEnum
{
    public static readonly OrganizationTemplateAllowedStrategyEnum Adfs = new(Values.Adfs);

    public static readonly OrganizationTemplateAllowedStrategyEnum GoogleApps = new(
        Values.GoogleApps
    );

    public static readonly OrganizationTemplateAllowedStrategyEnum Oidc = new(Values.Oidc);

    public static readonly OrganizationTemplateAllowedStrategyEnum Okta = new(Values.Okta);

    public static readonly OrganizationTemplateAllowedStrategyEnum Pingfederate = new(
        Values.Pingfederate
    );

    public static readonly OrganizationTemplateAllowedStrategyEnum Samlp = new(Values.Samlp);

    public static readonly OrganizationTemplateAllowedStrategyEnum Waad = new(Values.Waad);

    public OrganizationTemplateAllowedStrategyEnum(string value)
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
    public static OrganizationTemplateAllowedStrategyEnum FromCustom(string value)
    {
        return new OrganizationTemplateAllowedStrategyEnum(value);
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

    public static bool operator ==(OrganizationTemplateAllowedStrategyEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(OrganizationTemplateAllowedStrategyEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(OrganizationTemplateAllowedStrategyEnum value) =>
        value.Value;

    public static explicit operator OrganizationTemplateAllowedStrategyEnum(string value) =>
        new(value);

    internal class OrganizationTemplateAllowedStrategyEnumSerializer
        : JsonConverter<OrganizationTemplateAllowedStrategyEnum>
    {
        public override OrganizationTemplateAllowedStrategyEnum Read(
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
            return new OrganizationTemplateAllowedStrategyEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            OrganizationTemplateAllowedStrategyEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override OrganizationTemplateAllowedStrategyEnum ReadAsPropertyName(
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
            return new OrganizationTemplateAllowedStrategyEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            OrganizationTemplateAllowedStrategyEnum value,
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
        public const string Adfs = "adfs";

        public const string GoogleApps = "google-apps";

        public const string Oidc = "oidc";

        public const string Okta = "okta";

        public const string Pingfederate = "pingfederate";

        public const string Samlp = "samlp";

        public const string Waad = "waad";
    }
}
