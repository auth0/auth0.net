using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(IdentityProviderEnum.IdentityProviderEnumSerializer))]
[Serializable]
public readonly record struct IdentityProviderEnum : IStringEnum
{
    public static readonly IdentityProviderEnum Ad = new(Values.Ad);

    public static readonly IdentityProviderEnum Adfs = new(Values.Adfs);

    public static readonly IdentityProviderEnum Amazon = new(Values.Amazon);

    public static readonly IdentityProviderEnum Apple = new(Values.Apple);

    public static readonly IdentityProviderEnum Dropbox = new(Values.Dropbox);

    public static readonly IdentityProviderEnum Bitbucket = new(Values.Bitbucket);

    public static readonly IdentityProviderEnum Aol = new(Values.Aol);

    public static readonly IdentityProviderEnum Auth0Oidc = new(Values.Auth0Oidc);

    public static readonly IdentityProviderEnum Auth0 = new(Values.Auth0);

    public static readonly IdentityProviderEnum Baidu = new(Values.Baidu);

    public static readonly IdentityProviderEnum Bitly = new(Values.Bitly);

    public static readonly IdentityProviderEnum Box = new(Values.Box);

    public static readonly IdentityProviderEnum Custom = new(Values.Custom);

    public static readonly IdentityProviderEnum Daccount = new(Values.Daccount);

    public static readonly IdentityProviderEnum Dwolla = new(Values.Dwolla);

    public static readonly IdentityProviderEnum Email = new(Values.Email);

    public static readonly IdentityProviderEnum EvernoteSandbox = new(Values.EvernoteSandbox);

    public static readonly IdentityProviderEnum Evernote = new(Values.Evernote);

    public static readonly IdentityProviderEnum Exact = new(Values.Exact);

    public static readonly IdentityProviderEnum Facebook = new(Values.Facebook);

    public static readonly IdentityProviderEnum Fitbit = new(Values.Fitbit);

    public static readonly IdentityProviderEnum Flickr = new(Values.Flickr);

    public static readonly IdentityProviderEnum Github = new(Values.Github);

    public static readonly IdentityProviderEnum GoogleApps = new(Values.GoogleApps);

    public static readonly IdentityProviderEnum GoogleOauth2 = new(Values.GoogleOauth2);

    public static readonly IdentityProviderEnum Instagram = new(Values.Instagram);

    public static readonly IdentityProviderEnum Ip = new(Values.Ip);

    public static readonly IdentityProviderEnum Line = new(Values.Line);

    public static readonly IdentityProviderEnum Linkedin = new(Values.Linkedin);

    public static readonly IdentityProviderEnum Oauth1 = new(Values.Oauth1);

    public static readonly IdentityProviderEnum Oauth2 = new(Values.Oauth2);

    public static readonly IdentityProviderEnum Office365 = new(Values.Office365);

    public static readonly IdentityProviderEnum Oidc = new(Values.Oidc);

    public static readonly IdentityProviderEnum Okta = new(Values.Okta);

    public static readonly IdentityProviderEnum Paypal = new(Values.Paypal);

    public static readonly IdentityProviderEnum PaypalSandbox = new(Values.PaypalSandbox);

    public static readonly IdentityProviderEnum Pingfederate = new(Values.Pingfederate);

    public static readonly IdentityProviderEnum Planningcenter = new(Values.Planningcenter);

    public static readonly IdentityProviderEnum SalesforceCommunity = new(
        Values.SalesforceCommunity
    );

    public static readonly IdentityProviderEnum SalesforceSandbox = new(Values.SalesforceSandbox);

    public static readonly IdentityProviderEnum Salesforce = new(Values.Salesforce);

    public static readonly IdentityProviderEnum Samlp = new(Values.Samlp);

    public static readonly IdentityProviderEnum Sharepoint = new(Values.Sharepoint);

    public static readonly IdentityProviderEnum Shopify = new(Values.Shopify);

    public static readonly IdentityProviderEnum Shop = new(Values.Shop);

    public static readonly IdentityProviderEnum Sms = new(Values.Sms);

    public static readonly IdentityProviderEnum Soundcloud = new(Values.Soundcloud);

    public static readonly IdentityProviderEnum Thirtysevensignals = new(Values.Thirtysevensignals);

    public static readonly IdentityProviderEnum Twitter = new(Values.Twitter);

    public static readonly IdentityProviderEnum Untappd = new(Values.Untappd);

    public static readonly IdentityProviderEnum Vkontakte = new(Values.Vkontakte);

    public static readonly IdentityProviderEnum Waad = new(Values.Waad);

    public static readonly IdentityProviderEnum Weibo = new(Values.Weibo);

    public static readonly IdentityProviderEnum Windowslive = new(Values.Windowslive);

    public static readonly IdentityProviderEnum Wordpress = new(Values.Wordpress);

    public static readonly IdentityProviderEnum Yahoo = new(Values.Yahoo);

    public static readonly IdentityProviderEnum Yandex = new(Values.Yandex);

    public IdentityProviderEnum(string value)
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
    public static IdentityProviderEnum FromCustom(string value)
    {
        return new IdentityProviderEnum(value);
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

    public static bool operator ==(IdentityProviderEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdentityProviderEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdentityProviderEnum value) => value.Value;

    public static explicit operator IdentityProviderEnum(string value) => new(value);

    internal class IdentityProviderEnumSerializer : JsonConverter<IdentityProviderEnum>
    {
        public override IdentityProviderEnum Read(
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
            return new IdentityProviderEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdentityProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IdentityProviderEnum ReadAsPropertyName(
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
            return new IdentityProviderEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdentityProviderEnum value,
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

        public const string Aol = "aol";

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

        public const string Flickr = "flickr";

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
