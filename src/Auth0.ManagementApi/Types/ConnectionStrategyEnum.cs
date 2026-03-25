using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ConnectionStrategyEnum.ConnectionStrategyEnumSerializer))]
[Serializable]
public readonly record struct ConnectionStrategyEnum : IStringEnum
{
    public static readonly ConnectionStrategyEnum Ad = new(Values.Ad);

    public static readonly ConnectionStrategyEnum Adfs = new(Values.Adfs);

    public static readonly ConnectionStrategyEnum Amazon = new(Values.Amazon);

    public static readonly ConnectionStrategyEnum Apple = new(Values.Apple);

    public static readonly ConnectionStrategyEnum Dropbox = new(Values.Dropbox);

    public static readonly ConnectionStrategyEnum Bitbucket = new(Values.Bitbucket);

    public static readonly ConnectionStrategyEnum Aol = new(Values.Aol);

    public static readonly ConnectionStrategyEnum Auth0Oidc = new(Values.Auth0Oidc);

    public static readonly ConnectionStrategyEnum Auth0 = new(Values.Auth0);

    public static readonly ConnectionStrategyEnum Baidu = new(Values.Baidu);

    public static readonly ConnectionStrategyEnum Bitly = new(Values.Bitly);

    public static readonly ConnectionStrategyEnum Box = new(Values.Box);

    public static readonly ConnectionStrategyEnum Custom = new(Values.Custom);

    public static readonly ConnectionStrategyEnum Daccount = new(Values.Daccount);

    public static readonly ConnectionStrategyEnum Dwolla = new(Values.Dwolla);

    public static readonly ConnectionStrategyEnum Email = new(Values.Email);

    public static readonly ConnectionStrategyEnum EvernoteSandbox = new(Values.EvernoteSandbox);

    public static readonly ConnectionStrategyEnum Evernote = new(Values.Evernote);

    public static readonly ConnectionStrategyEnum Exact = new(Values.Exact);

    public static readonly ConnectionStrategyEnum Facebook = new(Values.Facebook);

    public static readonly ConnectionStrategyEnum Fitbit = new(Values.Fitbit);

    public static readonly ConnectionStrategyEnum Flickr = new(Values.Flickr);

    public static readonly ConnectionStrategyEnum Github = new(Values.Github);

    public static readonly ConnectionStrategyEnum GoogleApps = new(Values.GoogleApps);

    public static readonly ConnectionStrategyEnum GoogleOauth2 = new(Values.GoogleOauth2);

    public static readonly ConnectionStrategyEnum Instagram = new(Values.Instagram);

    public static readonly ConnectionStrategyEnum Ip = new(Values.Ip);

    public static readonly ConnectionStrategyEnum Line = new(Values.Line);

    public static readonly ConnectionStrategyEnum Linkedin = new(Values.Linkedin);

    public static readonly ConnectionStrategyEnum Miicard = new(Values.Miicard);

    public static readonly ConnectionStrategyEnum Oauth1 = new(Values.Oauth1);

    public static readonly ConnectionStrategyEnum Oauth2 = new(Values.Oauth2);

    public static readonly ConnectionStrategyEnum Office365 = new(Values.Office365);

    public static readonly ConnectionStrategyEnum Oidc = new(Values.Oidc);

    public static readonly ConnectionStrategyEnum Okta = new(Values.Okta);

    public static readonly ConnectionStrategyEnum Paypal = new(Values.Paypal);

    public static readonly ConnectionStrategyEnum PaypalSandbox = new(Values.PaypalSandbox);

    public static readonly ConnectionStrategyEnum Pingfederate = new(Values.Pingfederate);

    public static readonly ConnectionStrategyEnum Planningcenter = new(Values.Planningcenter);

    public static readonly ConnectionStrategyEnum Renren = new(Values.Renren);

    public static readonly ConnectionStrategyEnum SalesforceCommunity = new(
        Values.SalesforceCommunity
    );

    public static readonly ConnectionStrategyEnum SalesforceSandbox = new(Values.SalesforceSandbox);

    public static readonly ConnectionStrategyEnum Salesforce = new(Values.Salesforce);

    public static readonly ConnectionStrategyEnum Samlp = new(Values.Samlp);

    public static readonly ConnectionStrategyEnum Sharepoint = new(Values.Sharepoint);

    public static readonly ConnectionStrategyEnum Shopify = new(Values.Shopify);

    public static readonly ConnectionStrategyEnum Shop = new(Values.Shop);

    public static readonly ConnectionStrategyEnum Sms = new(Values.Sms);

    public static readonly ConnectionStrategyEnum Soundcloud = new(Values.Soundcloud);

    public static readonly ConnectionStrategyEnum ThecitySandbox = new(Values.ThecitySandbox);

    public static readonly ConnectionStrategyEnum Thecity = new(Values.Thecity);

    public static readonly ConnectionStrategyEnum Thirtysevensignals = new(
        Values.Thirtysevensignals
    );

    public static readonly ConnectionStrategyEnum Twitter = new(Values.Twitter);

    public static readonly ConnectionStrategyEnum Untappd = new(Values.Untappd);

    public static readonly ConnectionStrategyEnum Vkontakte = new(Values.Vkontakte);

    public static readonly ConnectionStrategyEnum Waad = new(Values.Waad);

    public static readonly ConnectionStrategyEnum Weibo = new(Values.Weibo);

    public static readonly ConnectionStrategyEnum Windowslive = new(Values.Windowslive);

    public static readonly ConnectionStrategyEnum Wordpress = new(Values.Wordpress);

    public static readonly ConnectionStrategyEnum Yahoo = new(Values.Yahoo);

    public static readonly ConnectionStrategyEnum Yammer = new(Values.Yammer);

    public static readonly ConnectionStrategyEnum Yandex = new(Values.Yandex);

    public static readonly ConnectionStrategyEnum Auth0Adldap = new(Values.Auth0Adldap);

    public ConnectionStrategyEnum(string value)
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
    public static ConnectionStrategyEnum FromCustom(string value)
    {
        return new ConnectionStrategyEnum(value);
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

    public static bool operator ==(ConnectionStrategyEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionStrategyEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionStrategyEnum value) => value.Value;

    public static explicit operator ConnectionStrategyEnum(string value) => new(value);

    internal class ConnectionStrategyEnumSerializer : JsonConverter<ConnectionStrategyEnum>
    {
        public override ConnectionStrategyEnum Read(
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
            return new ConnectionStrategyEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionStrategyEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ConnectionStrategyEnum ReadAsPropertyName(
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
            return new ConnectionStrategyEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionStrategyEnum value,
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

        public const string Miicard = "miicard";

        public const string Oauth1 = "oauth1";

        public const string Oauth2 = "oauth2";

        public const string Office365 = "office365";

        public const string Oidc = "oidc";

        public const string Okta = "okta";

        public const string Paypal = "paypal";

        public const string PaypalSandbox = "paypal-sandbox";

        public const string Pingfederate = "pingfederate";

        public const string Planningcenter = "planningcenter";

        public const string Renren = "renren";

        public const string SalesforceCommunity = "salesforce-community";

        public const string SalesforceSandbox = "salesforce-sandbox";

        public const string Salesforce = "salesforce";

        public const string Samlp = "samlp";

        public const string Sharepoint = "sharepoint";

        public const string Shopify = "shopify";

        public const string Shop = "shop";

        public const string Sms = "sms";

        public const string Soundcloud = "soundcloud";

        public const string ThecitySandbox = "thecity-sandbox";

        public const string Thecity = "thecity";

        public const string Thirtysevensignals = "thirtysevensignals";

        public const string Twitter = "twitter";

        public const string Untappd = "untappd";

        public const string Vkontakte = "vkontakte";

        public const string Waad = "waad";

        public const string Weibo = "weibo";

        public const string Windowslive = "windowslive";

        public const string Wordpress = "wordpress";

        public const string Yahoo = "yahoo";

        public const string Yammer = "yammer";

        public const string Yandex = "yandex";

        public const string Auth0Adldap = "auth0-adldap";
    }
}
