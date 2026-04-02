using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(AculContextEnum.AculContextEnumSerializer))]
[Serializable]
public readonly record struct AculContextEnum : IStringEnum
{
    public static readonly AculContextEnum BrandingSettings = new(Values.BrandingSettings);

    public static readonly AculContextEnum BrandingThemesDefault = new(
        Values.BrandingThemesDefault
    );

    public static readonly AculContextEnum ClientLogoUri = new(Values.ClientLogoUri);

    public static readonly AculContextEnum ClientDescription = new(Values.ClientDescription);

    public static readonly AculContextEnum OrganizationDisplayName = new(
        Values.OrganizationDisplayName
    );

    public static readonly AculContextEnum OrganizationBranding = new(Values.OrganizationBranding);

    public static readonly AculContextEnum ScreenTexts = new(Values.ScreenTexts);

    public static readonly AculContextEnum TenantName = new(Values.TenantName);

    public static readonly AculContextEnum TenantFriendlyName = new(Values.TenantFriendlyName);

    public static readonly AculContextEnum TenantLogoUrl = new(Values.TenantLogoUrl);

    public static readonly AculContextEnum TenantEnabledLocales = new(Values.TenantEnabledLocales);

    public static readonly AculContextEnum UntrustedDataSubmittedFormData = new(
        Values.UntrustedDataSubmittedFormData
    );

    public static readonly AculContextEnum UntrustedDataAuthorizationParamsLoginHint = new(
        Values.UntrustedDataAuthorizationParamsLoginHint
    );

    public static readonly AculContextEnum UntrustedDataAuthorizationParamsScreenHint = new(
        Values.UntrustedDataAuthorizationParamsScreenHint
    );

    public static readonly AculContextEnum UntrustedDataAuthorizationParamsUiLocales = new(
        Values.UntrustedDataAuthorizationParamsUiLocales
    );

    public static readonly AculContextEnum UserOrganizations = new(Values.UserOrganizations);

    public static readonly AculContextEnum TransactionCustomDomainDomain = new(
        Values.TransactionCustomDomainDomain
    );

    public AculContextEnum(string value)
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
    public static AculContextEnum FromCustom(string value)
    {
        return new AculContextEnum(value);
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

    public static bool operator ==(AculContextEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AculContextEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AculContextEnum value) => value.Value;

    public static explicit operator AculContextEnum(string value) => new(value);

    internal class AculContextEnumSerializer : JsonConverter<AculContextEnum>
    {
        public override AculContextEnum Read(
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
            return new AculContextEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            AculContextEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override AculContextEnum ReadAsPropertyName(
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
            return new AculContextEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AculContextEnum value,
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
        public const string BrandingSettings = "branding.settings";

        public const string BrandingThemesDefault = "branding.themes.default";

        public const string ClientLogoUri = "client.logo_uri";

        public const string ClientDescription = "client.description";

        public const string OrganizationDisplayName = "organization.display_name";

        public const string OrganizationBranding = "organization.branding";

        public const string ScreenTexts = "screen.texts";

        public const string TenantName = "tenant.name";

        public const string TenantFriendlyName = "tenant.friendly_name";

        public const string TenantLogoUrl = "tenant.logo_url";

        public const string TenantEnabledLocales = "tenant.enabled_locales";

        public const string UntrustedDataSubmittedFormData = "untrusted_data.submitted_form_data";

        public const string UntrustedDataAuthorizationParamsLoginHint =
            "untrusted_data.authorization_params.login_hint";

        public const string UntrustedDataAuthorizationParamsScreenHint =
            "untrusted_data.authorization_params.screen_hint";

        public const string UntrustedDataAuthorizationParamsUiLocales =
            "untrusted_data.authorization_params.ui_locales";

        public const string UserOrganizations = "user.organizations";

        public const string TransactionCustomDomainDomain = "transaction.custom_domain.domain";
    }
}
