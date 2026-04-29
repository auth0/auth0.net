using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum.EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Amazon =
        new(Values.Amazon);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Apple =
        new(Values.Apple);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Dropbox =
        new(Values.Dropbox);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Bitbucket =
        new(Values.Bitbucket);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Auth0Oidc =
        new(Values.Auth0Oidc);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Baidu =
        new(Values.Baidu);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Bitly =
        new(Values.Bitly);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Box =
        new(Values.Box);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Daccount =
        new(Values.Daccount);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Dwolla =
        new(Values.Dwolla);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum EvernoteSandbox =
        new(Values.EvernoteSandbox);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Evernote =
        new(Values.Evernote);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Exact =
        new(Values.Exact);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Facebook =
        new(Values.Facebook);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Fitbit =
        new(Values.Fitbit);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Github =
        new(Values.Github);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum GoogleOauth2 =
        new(Values.GoogleOauth2);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Instagram =
        new(Values.Instagram);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Line =
        new(Values.Line);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Linkedin =
        new(Values.Linkedin);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Oauth1 =
        new(Values.Oauth1);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Oauth2 =
        new(Values.Oauth2);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Paypal =
        new(Values.Paypal);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum PaypalSandbox =
        new(Values.PaypalSandbox);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Planningcenter =
        new(Values.Planningcenter);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum SalesforceCommunity =
        new(Values.SalesforceCommunity);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum SalesforceSandbox =
        new(Values.SalesforceSandbox);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Salesforce =
        new(Values.Salesforce);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Shopify =
        new(Values.Shopify);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Soundcloud =
        new(Values.Soundcloud);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Thirtysevensignals =
        new(Values.Thirtysevensignals);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Twitter =
        new(Values.Twitter);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Untapped =
        new(Values.Untapped);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Vkontakte =
        new(Values.Vkontakte);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Weibo =
        new(Values.Weibo);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Windowslive =
        new(Values.Windowslive);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Wordpress =
        new(Values.Wordpress);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Yahoo =
        new(Values.Yahoo);

    public static readonly EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Yandex =
        new(Values.Yandex);

    public EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum(string value)
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
    public static EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum(value);
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

    public static bool operator ==(
        EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnumSerializer
        : JsonConverter<EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum>
    {
        public override EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum Read(
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
            return new EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserDeletedObjectIdentitiesItemSocialProviderEnum value,
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
        public const string Amazon = "amazon";

        public const string Apple = "apple";

        public const string Dropbox = "dropbox";

        public const string Bitbucket = "bitbucket";

        public const string Auth0Oidc = "auth0-oidc";

        public const string Baidu = "baidu";

        public const string Bitly = "bitly";

        public const string Box = "box";

        public const string Daccount = "daccount";

        public const string Dwolla = "dwolla";

        public const string EvernoteSandbox = "evernote-sandbox";

        public const string Evernote = "evernote";

        public const string Exact = "exact";

        public const string Facebook = "facebook";

        public const string Fitbit = "fitbit";

        public const string Github = "github";

        public const string GoogleOauth2 = "google-oauth2";

        public const string Instagram = "instagram";

        public const string Line = "line";

        public const string Linkedin = "linkedin";

        public const string Oauth1 = "oauth1";

        public const string Oauth2 = "oauth2";

        public const string Paypal = "paypal";

        public const string PaypalSandbox = "paypal-sandbox";

        public const string Planningcenter = "planningcenter";

        public const string SalesforceCommunity = "salesforce-community";

        public const string SalesforceSandbox = "salesforce-sandbox";

        public const string Salesforce = "salesforce";

        public const string Shopify = "shopify";

        public const string Soundcloud = "soundcloud";

        public const string Thirtysevensignals = "thirtysevensignals";

        public const string Twitter = "twitter";

        public const string Untapped = "untapped";

        public const string Vkontakte = "vkontakte";

        public const string Weibo = "weibo";

        public const string Windowslive = "windowslive";

        public const string Wordpress = "wordpress";

        public const string Yahoo = "yahoo";

        public const string Yandex = "yandex";
    }
}
