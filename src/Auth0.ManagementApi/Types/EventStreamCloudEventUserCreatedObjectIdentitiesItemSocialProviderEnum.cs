using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum.EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Amazon =
        new(Values.Amazon);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Apple =
        new(Values.Apple);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Dropbox =
        new(Values.Dropbox);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Bitbucket =
        new(Values.Bitbucket);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Auth0Oidc =
        new(Values.Auth0Oidc);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Baidu =
        new(Values.Baidu);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Bitly =
        new(Values.Bitly);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Box =
        new(Values.Box);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Daccount =
        new(Values.Daccount);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Dwolla =
        new(Values.Dwolla);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum EvernoteSandbox =
        new(Values.EvernoteSandbox);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Evernote =
        new(Values.Evernote);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Exact =
        new(Values.Exact);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Facebook =
        new(Values.Facebook);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Fitbit =
        new(Values.Fitbit);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Github =
        new(Values.Github);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum GoogleOauth2 =
        new(Values.GoogleOauth2);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Instagram =
        new(Values.Instagram);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Line =
        new(Values.Line);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Linkedin =
        new(Values.Linkedin);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Oauth1 =
        new(Values.Oauth1);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Oauth2 =
        new(Values.Oauth2);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Paypal =
        new(Values.Paypal);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum PaypalSandbox =
        new(Values.PaypalSandbox);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Planningcenter =
        new(Values.Planningcenter);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum SalesforceCommunity =
        new(Values.SalesforceCommunity);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum SalesforceSandbox =
        new(Values.SalesforceSandbox);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Salesforce =
        new(Values.Salesforce);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Shopify =
        new(Values.Shopify);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Soundcloud =
        new(Values.Soundcloud);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Thirtysevensignals =
        new(Values.Thirtysevensignals);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Twitter =
        new(Values.Twitter);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Untapped =
        new(Values.Untapped);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Vkontakte =
        new(Values.Vkontakte);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Weibo =
        new(Values.Weibo);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Windowslive =
        new(Values.Windowslive);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Wordpress =
        new(Values.Wordpress);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Yahoo =
        new(Values.Yahoo);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Yandex =
        new(Values.Yandex);

    public EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum(string value)
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
    public static EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum(value);
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
        EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnumSerializer
        : JsonConverter<EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum>
    {
        public override EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum Read(
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
            return new EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedObjectIdentitiesItemSocialProviderEnum value,
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
