using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum.EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Amazon =
        new(Values.Amazon);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Apple =
        new(Values.Apple);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Dropbox =
        new(Values.Dropbox);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Bitbucket =
        new(Values.Bitbucket);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Auth0Oidc =
        new(Values.Auth0Oidc);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Baidu =
        new(Values.Baidu);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Bitly =
        new(Values.Bitly);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Box =
        new(Values.Box);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Daccount =
        new(Values.Daccount);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Dwolla =
        new(Values.Dwolla);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum EvernoteSandbox =
        new(Values.EvernoteSandbox);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Evernote =
        new(Values.Evernote);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Exact =
        new(Values.Exact);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Facebook =
        new(Values.Facebook);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Fitbit =
        new(Values.Fitbit);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Github =
        new(Values.Github);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum GoogleOauth2 =
        new(Values.GoogleOauth2);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Instagram =
        new(Values.Instagram);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Line =
        new(Values.Line);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Linkedin =
        new(Values.Linkedin);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Oauth1 =
        new(Values.Oauth1);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Oauth2 =
        new(Values.Oauth2);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Paypal =
        new(Values.Paypal);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum PaypalSandbox =
        new(Values.PaypalSandbox);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Planningcenter =
        new(Values.Planningcenter);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum SalesforceCommunity =
        new(Values.SalesforceCommunity);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum SalesforceSandbox =
        new(Values.SalesforceSandbox);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Salesforce =
        new(Values.Salesforce);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Shopify =
        new(Values.Shopify);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Soundcloud =
        new(Values.Soundcloud);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Thirtysevensignals =
        new(Values.Thirtysevensignals);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Twitter =
        new(Values.Twitter);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Untapped =
        new(Values.Untapped);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Vkontakte =
        new(Values.Vkontakte);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Weibo =
        new(Values.Weibo);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Windowslive =
        new(Values.Windowslive);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Wordpress =
        new(Values.Wordpress);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Yahoo =
        new(Values.Yahoo);

    public static readonly EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Yandex =
        new(Values.Yandex);

    public EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum(
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
    public static EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum(
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
        EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnumSerializer
        : JsonConverter<EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum>
    {
        public override EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum Read(
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
            return new EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserUpdatedPreviousObjectIdentitiesItemSocialProviderEnum value,
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
