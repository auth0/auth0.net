using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(UserIdentityProviderEnum.UserIdentityProviderEnumSerializer))]
[Serializable]
public readonly record struct UserIdentityProviderEnum : IStringEnum
{
    public static readonly UserIdentityProviderEnum Ad = new(Values.Ad);

    public static readonly UserIdentityProviderEnum Adfs = new(Values.Adfs);

    public static readonly UserIdentityProviderEnum Amazon = new(Values.Amazon);

    public static readonly UserIdentityProviderEnum Apple = new(Values.Apple);

    public static readonly UserIdentityProviderEnum Dropbox = new(Values.Dropbox);

    public static readonly UserIdentityProviderEnum Bitbucket = new(Values.Bitbucket);

    public static readonly UserIdentityProviderEnum Auth0Oidc = new(Values.Auth0Oidc);

    public static readonly UserIdentityProviderEnum Auth0 = new(Values.Auth0);

    public static readonly UserIdentityProviderEnum Baidu = new(Values.Baidu);

    public static readonly UserIdentityProviderEnum Bitly = new(Values.Bitly);

    public static readonly UserIdentityProviderEnum Box = new(Values.Box);

    public static readonly UserIdentityProviderEnum Custom = new(Values.Custom);

    public static readonly UserIdentityProviderEnum Daccount = new(Values.Daccount);

    public static readonly UserIdentityProviderEnum Dwolla = new(Values.Dwolla);

    public static readonly UserIdentityProviderEnum Email = new(Values.Email);

    public static readonly UserIdentityProviderEnum EvernoteSandbox = new(Values.EvernoteSandbox);

    public static readonly UserIdentityProviderEnum Evernote = new(Values.Evernote);

    public static readonly UserIdentityProviderEnum Exact = new(Values.Exact);

    public static readonly UserIdentityProviderEnum Facebook = new(Values.Facebook);

    public static readonly UserIdentityProviderEnum Fitbit = new(Values.Fitbit);

    public static readonly UserIdentityProviderEnum Github = new(Values.Github);

    public static readonly UserIdentityProviderEnum GoogleApps = new(Values.GoogleApps);

    public static readonly UserIdentityProviderEnum GoogleOauth2 = new(Values.GoogleOauth2);

    public static readonly UserIdentityProviderEnum Instagram = new(Values.Instagram);

    public static readonly UserIdentityProviderEnum Ip = new(Values.Ip);

    public static readonly UserIdentityProviderEnum Line = new(Values.Line);

    public static readonly UserIdentityProviderEnum Linkedin = new(Values.Linkedin);

    public static readonly UserIdentityProviderEnum Oauth1 = new(Values.Oauth1);

    public static readonly UserIdentityProviderEnum Oauth2 = new(Values.Oauth2);

    public static readonly UserIdentityProviderEnum Office365 = new(Values.Office365);

    public static readonly UserIdentityProviderEnum Oidc = new(Values.Oidc);

    public static readonly UserIdentityProviderEnum Okta = new(Values.Okta);

    public static readonly UserIdentityProviderEnum Paypal = new(Values.Paypal);

    public static readonly UserIdentityProviderEnum PaypalSandbox = new(Values.PaypalSandbox);

    public static readonly UserIdentityProviderEnum Pingfederate = new(Values.Pingfederate);

    public static readonly UserIdentityProviderEnum Planningcenter = new(Values.Planningcenter);

    public static readonly UserIdentityProviderEnum SalesforceCommunity = new(
        Values.SalesforceCommunity
    );

    public static readonly UserIdentityProviderEnum SalesforceSandbox = new(
        Values.SalesforceSandbox
    );

    public static readonly UserIdentityProviderEnum Salesforce = new(Values.Salesforce);

    public static readonly UserIdentityProviderEnum Samlp = new(Values.Samlp);

    public static readonly UserIdentityProviderEnum Sharepoint = new(Values.Sharepoint);

    public static readonly UserIdentityProviderEnum Shopify = new(Values.Shopify);

    public static readonly UserIdentityProviderEnum Shop = new(Values.Shop);

    public static readonly UserIdentityProviderEnum Sms = new(Values.Sms);

    public static readonly UserIdentityProviderEnum Soundcloud = new(Values.Soundcloud);

    public static readonly UserIdentityProviderEnum Thirtysevensignals = new(
        Values.Thirtysevensignals
    );

    public static readonly UserIdentityProviderEnum Twitter = new(Values.Twitter);

    public static readonly UserIdentityProviderEnum Untappd = new(Values.Untappd);

    public static readonly UserIdentityProviderEnum Vkontakte = new(Values.Vkontakte);

    public static readonly UserIdentityProviderEnum Waad = new(Values.Waad);

    public static readonly UserIdentityProviderEnum Weibo = new(Values.Weibo);

    public static readonly UserIdentityProviderEnum Windowslive = new(Values.Windowslive);

    public static readonly UserIdentityProviderEnum Wordpress = new(Values.Wordpress);

    public static readonly UserIdentityProviderEnum Yahoo = new(Values.Yahoo);

    public static readonly UserIdentityProviderEnum Yandex = new(Values.Yandex);

    public UserIdentityProviderEnum(string value)
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
    public static UserIdentityProviderEnum FromCustom(string value)
    {
        return new UserIdentityProviderEnum(value);
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

    public static bool operator ==(UserIdentityProviderEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UserIdentityProviderEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UserIdentityProviderEnum value) => value.Value;

    public static explicit operator UserIdentityProviderEnum(string value) => new(value);

    internal class UserIdentityProviderEnumSerializer : JsonConverter<UserIdentityProviderEnum>
    {
        public override UserIdentityProviderEnum Read(
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
            return new UserIdentityProviderEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            UserIdentityProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override UserIdentityProviderEnum ReadAsPropertyName(
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
            return new UserIdentityProviderEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UserIdentityProviderEnum value,
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
        public const string Ad = "ad";

        public const string Adfs = "adfs";

        public const string Amazon = "amazon";

        public const string Apple = "apple";

        public const string Dropbox = "dropbox";

        public const string Bitbucket = "bitbucket";

        public const string Auth0Oidc = "auth0-oidc";

        public const string Auth0 = "auth0";

        public const string Baidu = "baidu";

        public const string Bitly = "bitly";

        public const string Box = "box";

        public const string Custom = "custom";

        public const string Daccount = "daccount";

        public const string Dwolla = "dwolla";

        public const string Email = "email";

        public const string EvernoteSandbox = "evernote-sandbox";

        public const string Evernote = "evernote";

        public const string Exact = "exact";

        public const string Facebook = "facebook";

        public const string Fitbit = "fitbit";

        public const string Github = "github";

        public const string GoogleApps = "google-apps";

        public const string GoogleOauth2 = "google-oauth2";

        public const string Instagram = "instagram";

        public const string Ip = "ip";

        public const string Line = "line";

        public const string Linkedin = "linkedin";

        public const string Oauth1 = "oauth1";

        public const string Oauth2 = "oauth2";

        public const string Office365 = "office365";

        public const string Oidc = "oidc";

        public const string Okta = "okta";

        public const string Paypal = "paypal";

        public const string PaypalSandbox = "paypal-sandbox";

        public const string Pingfederate = "pingfederate";

        public const string Planningcenter = "planningcenter";

        public const string SalesforceCommunity = "salesforce-community";

        public const string SalesforceSandbox = "salesforce-sandbox";

        public const string Salesforce = "salesforce";

        public const string Samlp = "samlp";

        public const string Sharepoint = "sharepoint";

        public const string Shopify = "shopify";

        public const string Shop = "shop";

        public const string Sms = "sms";

        public const string Soundcloud = "soundcloud";

        public const string Thirtysevensignals = "thirtysevensignals";

        public const string Twitter = "twitter";

        public const string Untappd = "untappd";

        public const string Vkontakte = "vkontakte";

        public const string Waad = "waad";

        public const string Weibo = "weibo";

        public const string Windowslive = "windowslive";

        public const string Wordpress = "wordpress";

        public const string Yahoo = "yahoo";

        public const string Yandex = "yandex";
    }
}
