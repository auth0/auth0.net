using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum.EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Amazon =
        new(Values.Amazon);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Apple =
        new(Values.Apple);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Dropbox =
        new(Values.Dropbox);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Bitbucket =
        new(Values.Bitbucket);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Auth0Oidc =
        new(Values.Auth0Oidc);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Baidu =
        new(Values.Baidu);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Bitly =
        new(Values.Bitly);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Box =
        new(Values.Box);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Daccount =
        new(Values.Daccount);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Dwolla =
        new(Values.Dwolla);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum EvernoteSandbox =
        new(Values.EvernoteSandbox);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Evernote =
        new(Values.Evernote);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Exact =
        new(Values.Exact);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Facebook =
        new(Values.Facebook);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Fitbit =
        new(Values.Fitbit);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Github =
        new(Values.Github);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum GoogleOauth2 =
        new(Values.GoogleOauth2);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Instagram =
        new(Values.Instagram);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Line =
        new(Values.Line);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Linkedin =
        new(Values.Linkedin);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Oauth1 =
        new(Values.Oauth1);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Oauth2 =
        new(Values.Oauth2);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Paypal =
        new(Values.Paypal);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum PaypalSandbox =
        new(Values.PaypalSandbox);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Planningcenter =
        new(Values.Planningcenter);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum SalesforceCommunity =
        new(Values.SalesforceCommunity);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum SalesforceSandbox =
        new(Values.SalesforceSandbox);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Salesforce =
        new(Values.Salesforce);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Shopify =
        new(Values.Shopify);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Soundcloud =
        new(Values.Soundcloud);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Thirtysevensignals =
        new(Values.Thirtysevensignals);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Twitter =
        new(Values.Twitter);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Untapped =
        new(Values.Untapped);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Vkontakte =
        new(Values.Vkontakte);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Weibo =
        new(Values.Weibo);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Windowslive =
        new(Values.Windowslive);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Wordpress =
        new(Values.Wordpress);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Yahoo =
        new(Values.Yahoo);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Yandex =
        new(Values.Yandex);

    public EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum(string value)
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
    public static EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum(value);
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
        EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnumSerializer
        : JsonConverter<EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum>
    {
        public override EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum Read(
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
            return new EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserUpdatedObjectIdentitiesItemSocialProviderEnum value,
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
