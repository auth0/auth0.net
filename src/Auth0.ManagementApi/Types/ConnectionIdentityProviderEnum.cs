using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ConnectionIdentityProviderEnum.ConnectionIdentityProviderEnumSerializer))]
[Serializable]
public readonly record struct ConnectionIdentityProviderEnum : IStringEnum
{
    public static readonly ConnectionIdentityProviderEnum Ad = new(Values.Ad);

    public static readonly ConnectionIdentityProviderEnum Adfs = new(Values.Adfs);

    public static readonly ConnectionIdentityProviderEnum Amazon = new(Values.Amazon);

    public static readonly ConnectionIdentityProviderEnum Apple = new(Values.Apple);

    public static readonly ConnectionIdentityProviderEnum Dropbox = new(Values.Dropbox);

    public static readonly ConnectionIdentityProviderEnum Bitbucket = new(Values.Bitbucket);

    public static readonly ConnectionIdentityProviderEnum Auth0Oidc = new(Values.Auth0Oidc);

    public static readonly ConnectionIdentityProviderEnum Auth0 = new(Values.Auth0);

    public static readonly ConnectionIdentityProviderEnum Baidu = new(Values.Baidu);

    public static readonly ConnectionIdentityProviderEnum Bitly = new(Values.Bitly);

    public static readonly ConnectionIdentityProviderEnum Box = new(Values.Box);

    public static readonly ConnectionIdentityProviderEnum Custom = new(Values.Custom);

    public static readonly ConnectionIdentityProviderEnum Daccount = new(Values.Daccount);

    public static readonly ConnectionIdentityProviderEnum Dwolla = new(Values.Dwolla);

    public static readonly ConnectionIdentityProviderEnum Email = new(Values.Email);

    public static readonly ConnectionIdentityProviderEnum EvernoteSandbox = new(
        Values.EvernoteSandbox
    );

    public static readonly ConnectionIdentityProviderEnum Evernote = new(Values.Evernote);

    public static readonly ConnectionIdentityProviderEnum Exact = new(Values.Exact);

    public static readonly ConnectionIdentityProviderEnum Facebook = new(Values.Facebook);

    public static readonly ConnectionIdentityProviderEnum Fitbit = new(Values.Fitbit);

    public static readonly ConnectionIdentityProviderEnum Github = new(Values.Github);

    public static readonly ConnectionIdentityProviderEnum GoogleApps = new(Values.GoogleApps);

    public static readonly ConnectionIdentityProviderEnum GoogleOauth2 = new(Values.GoogleOauth2);

    public static readonly ConnectionIdentityProviderEnum Instagram = new(Values.Instagram);

    public static readonly ConnectionIdentityProviderEnum Ip = new(Values.Ip);

    public static readonly ConnectionIdentityProviderEnum Line = new(Values.Line);

    public static readonly ConnectionIdentityProviderEnum Linkedin = new(Values.Linkedin);

    public static readonly ConnectionIdentityProviderEnum Oauth1 = new(Values.Oauth1);

    public static readonly ConnectionIdentityProviderEnum Oauth2 = new(Values.Oauth2);

    public static readonly ConnectionIdentityProviderEnum Office365 = new(Values.Office365);

    public static readonly ConnectionIdentityProviderEnum Oidc = new(Values.Oidc);

    public static readonly ConnectionIdentityProviderEnum Okta = new(Values.Okta);

    public static readonly ConnectionIdentityProviderEnum Paypal = new(Values.Paypal);

    public static readonly ConnectionIdentityProviderEnum PaypalSandbox = new(Values.PaypalSandbox);

    public static readonly ConnectionIdentityProviderEnum Pingfederate = new(Values.Pingfederate);

    public static readonly ConnectionIdentityProviderEnum Planningcenter = new(
        Values.Planningcenter
    );

    public static readonly ConnectionIdentityProviderEnum SalesforceCommunity = new(
        Values.SalesforceCommunity
    );

    public static readonly ConnectionIdentityProviderEnum SalesforceSandbox = new(
        Values.SalesforceSandbox
    );

    public static readonly ConnectionIdentityProviderEnum Salesforce = new(Values.Salesforce);

    public static readonly ConnectionIdentityProviderEnum Samlp = new(Values.Samlp);

    public static readonly ConnectionIdentityProviderEnum Sharepoint = new(Values.Sharepoint);

    public static readonly ConnectionIdentityProviderEnum Shopify = new(Values.Shopify);

    public static readonly ConnectionIdentityProviderEnum Shop = new(Values.Shop);

    public static readonly ConnectionIdentityProviderEnum Sms = new(Values.Sms);

    public static readonly ConnectionIdentityProviderEnum Soundcloud = new(Values.Soundcloud);

    public static readonly ConnectionIdentityProviderEnum Thirtysevensignals = new(
        Values.Thirtysevensignals
    );

    public static readonly ConnectionIdentityProviderEnum Twitter = new(Values.Twitter);

    public static readonly ConnectionIdentityProviderEnum Untappd = new(Values.Untappd);

    public static readonly ConnectionIdentityProviderEnum Vkontakte = new(Values.Vkontakte);

    public static readonly ConnectionIdentityProviderEnum Waad = new(Values.Waad);

    public static readonly ConnectionIdentityProviderEnum Weibo = new(Values.Weibo);

    public static readonly ConnectionIdentityProviderEnum Windowslive = new(Values.Windowslive);

    public static readonly ConnectionIdentityProviderEnum Wordpress = new(Values.Wordpress);

    public static readonly ConnectionIdentityProviderEnum Yahoo = new(Values.Yahoo);

    public static readonly ConnectionIdentityProviderEnum Yandex = new(Values.Yandex);

    public ConnectionIdentityProviderEnum(string value)
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
    public static ConnectionIdentityProviderEnum FromCustom(string value)
    {
        return new ConnectionIdentityProviderEnum(value);
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

    public static bool operator ==(ConnectionIdentityProviderEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionIdentityProviderEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionIdentityProviderEnum value) => value.Value;

    public static explicit operator ConnectionIdentityProviderEnum(string value) => new(value);

    internal class ConnectionIdentityProviderEnumSerializer
        : JsonConverter<ConnectionIdentityProviderEnum>
    {
        public override ConnectionIdentityProviderEnum Read(
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
            return new ConnectionIdentityProviderEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionIdentityProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionIdentityProviderEnum ReadAsPropertyName(
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
            return new ConnectionIdentityProviderEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionIdentityProviderEnum value,
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
