using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Amazon =
        new(Values.Amazon);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Apple =
        new(Values.Apple);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Dropbox =
        new(Values.Dropbox);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Bitbucket =
        new(Values.Bitbucket);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Auth0Oidc =
        new(Values.Auth0Oidc);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Baidu =
        new(Values.Baidu);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Bitly =
        new(Values.Bitly);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Box =
        new(Values.Box);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Daccount =
        new(Values.Daccount);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Dwolla =
        new(Values.Dwolla);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum EvernoteSandbox =
        new(Values.EvernoteSandbox);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Evernote =
        new(Values.Evernote);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Exact =
        new(Values.Exact);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Facebook =
        new(Values.Facebook);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Fitbit =
        new(Values.Fitbit);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Github =
        new(Values.Github);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum GoogleOauth2 =
        new(Values.GoogleOauth2);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Instagram =
        new(Values.Instagram);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Line =
        new(Values.Line);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Linkedin =
        new(Values.Linkedin);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Oauth1 =
        new(Values.Oauth1);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Oauth2 =
        new(Values.Oauth2);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Paypal =
        new(Values.Paypal);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum PaypalSandbox =
        new(Values.PaypalSandbox);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Planningcenter =
        new(Values.Planningcenter);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum SalesforceCommunity =
        new(Values.SalesforceCommunity);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum SalesforceSandbox =
        new(Values.SalesforceSandbox);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Salesforce =
        new(Values.Salesforce);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Shopify =
        new(Values.Shopify);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Soundcloud =
        new(Values.Soundcloud);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Thirtysevensignals =
        new(Values.Thirtysevensignals);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Twitter =
        new(Values.Twitter);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Untapped =
        new(Values.Untapped);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Vkontakte =
        new(Values.Vkontakte);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Weibo =
        new(Values.Weibo);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Windowslive =
        new(Values.Windowslive);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Wordpress =
        new(Values.Wordpress);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Yahoo =
        new(Values.Yahoo);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Yandex =
        new(Values.Yandex);

    public EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum(
        string value
    )
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
    public static EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum(
            value
        );
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
        EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnumSerializer
        : JsonConverter<EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum>
    {
        public override EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum Read(
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
            return new EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemSocialProviderEnum value,
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
