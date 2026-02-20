using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'facebook' connection
/// </summary>
[Serializable]
public record ConnectionOptionsFacebook : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    [Optional]
    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; set; }

    [Optional]
    [JsonPropertyName("freeform_scopes")]
    public IEnumerable<string>? FreeformScopes { get; set; }

    [Optional]
    [JsonPropertyName("upstream_params")]
    public Dictionary<string, ConnectionUpstreamAdditionalProperties>? UpstreamParams { get; set; }

    [Optional]
    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public ConnectionSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    /// <summary>
    /// Grants permission to both read and manage ads for ad accounts you own or have been granted access to by the owner. By default, your app may only access ad accounts owned by admins of the app when in developer mode.
    /// </summary>
    [Optional]
    [JsonPropertyName("ads_management")]
    public bool? AdsManagement { get; set; }

    /// <summary>
    /// Grants access to the Ads Insights API to pull ads report information for ad accounts you own or have been granted access to by the owner of other ad accounts.
    /// </summary>
    [Optional]
    [JsonPropertyName("ads_read")]
    public bool? AdsRead { get; set; }

    /// <summary>
    /// Provides access to a social context. Deprecated on April 30th, 2019.
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_context_profile_field")]
    public bool? AllowContextProfileField { get; set; }

    /// <summary>
    /// Grants permission to read and write with the Business Manager API.
    /// </summary>
    [Optional]
    [JsonPropertyName("business_management")]
    public bool? BusinessManagement { get; set; }

    /// <summary>
    /// Grants permission to access a person's primary email address.
    /// </summary>
    [Optional]
    [JsonPropertyName("email")]
    public bool? Email { get; set; }

    /// <summary>
    /// Grants permission to publicly available group member information.
    /// </summary>
    [Optional]
    [JsonPropertyName("groups_access_member_info")]
    public bool? GroupsAccessMemberInfo { get; set; }

    /// <summary>
    /// Grants permission to retrieve all the information captured within a lead.
    /// </summary>
    [Optional]
    [JsonPropertyName("leads_retrieval")]
    public bool? LeadsRetrieval { get; set; }

    /// <summary>
    /// Enables your app to read a person's notifications and mark them as read. This permission does not let you send notifications to a person. Deprecated in Graph API v2.3.
    /// </summary>
    [Optional]
    [JsonPropertyName("manage_notifications")]
    public bool? ManageNotifications { get; set; }

    /// <summary>
    /// Grants permission to retrieve Page Access Tokens for the Pages and Apps that the person administers. Apps need both manage_pages and publish_pages to be able to publish as a Page.
    /// </summary>
    [Optional]
    [JsonPropertyName("manage_pages")]
    public bool? ManagePages { get; set; }

    /// <summary>
    /// Allows the app to perform POST and DELETE operations on endpoints used for managing a Page's Call To Action buttons.
    /// </summary>
    [Optional]
    [JsonPropertyName("pages_manage_cta")]
    public bool? PagesManageCta { get; set; }

    /// <summary>
    /// Grants permission to manage Instant Articles on behalf of Facebook Pages administered by people using your app.
    /// </summary>
    [Optional]
    [JsonPropertyName("pages_manage_instant_articles")]
    public bool? PagesManageInstantArticles { get; set; }

    /// <summary>
    /// Grants permission to send and receive messages through a Facebook Page.
    /// </summary>
    [Optional]
    [JsonPropertyName("pages_messaging")]
    public bool? PagesMessaging { get; set; }

    /// <summary>
    /// Grants permission to use the phone number messaging feature.
    /// </summary>
    [Optional]
    [JsonPropertyName("pages_messaging_phone_number")]
    public bool? PagesMessagingPhoneNumber { get; set; }

    /// <summary>
    /// Grants permission to send messages using Facebook Pages at any time after the first user interaction. Your app may only send advertising or promotional content through sponsored messages or within 24 hours of user interaction.
    /// </summary>
    [Optional]
    [JsonPropertyName("pages_messaging_subscriptions")]
    public bool? PagesMessagingSubscriptions { get; set; }

    /// <summary>
    /// Grants access to show the list of the Pages that a person manages.
    /// </summary>
    [Optional]
    [JsonPropertyName("pages_show_list")]
    public bool? PagesShowList { get; set; }

    /// <summary>
    /// Provides access to a user's public profile information including id, first_name, last_name, middle_name, name, name_format, picture, and short_name. This is the most basic permission and is required by Facebook.
    /// </summary>
    [Optional]
    [JsonPropertyName("public_profile")]
    public bool? PublicProfile { get; set; }

    /// <summary>
    /// Allows your app to publish to the Open Graph using Built-in Actions, Achievements, Scores, or Custom Actions. Deprecated on August 1st, 2018.
    /// </summary>
    [Optional]
    [JsonPropertyName("publish_actions")]
    public bool? PublishActions { get; set; }

    /// <summary>
    /// Grants permission to publish posts, comments, and like Pages managed by a person using your app. Your app must also have manage_pages to publish as a Page.
    /// </summary>
    [Optional]
    [JsonPropertyName("publish_pages")]
    public bool? PublishPages { get; set; }

    /// <summary>
    /// Grants permission to post content into a group on behalf of a user who has granted the app this permission.
    /// </summary>
    [Optional]
    [JsonPropertyName("publish_to_groups")]
    public bool? PublishToGroups { get; set; }

    /// <summary>
    /// Grants permission to publish live videos to the app User's timeline.
    /// </summary>
    [Optional]
    [JsonPropertyName("publish_video")]
    public bool? PublishVideo { get; set; }

    /// <summary>
    /// Grants read-only access to the Audience Network Insights data for Apps the person owns.
    /// </summary>
    [Optional]
    [JsonPropertyName("read_audience_network_insights")]
    public bool? ReadAudienceNetworkInsights { get; set; }

    /// <summary>
    /// Grants read-only access to the Insights data for Pages, Apps, and web domains the person owns.
    /// </summary>
    [Optional]
    [JsonPropertyName("read_insights")]
    public bool? ReadInsights { get; set; }

    /// <summary>
    /// Provides the ability to read the messages in a person's Facebook Inbox through the inbox edge and the thread node. Deprecated in Graph API v2.3.
    /// </summary>
    [Optional]
    [JsonPropertyName("read_mailbox")]
    public bool? ReadMailbox { get; set; }

    /// <summary>
    /// Grants permission to read from the Page Inboxes of the Pages managed by a person. This permission is often used alongside the manage_pages permission.
    /// </summary>
    [Optional]
    [JsonPropertyName("read_page_mailboxes")]
    public bool? ReadPageMailboxes { get; set; }

    /// <summary>
    /// Provides access to read the posts in a person's News Feed, or the posts on their Profile. Deprecated in Graph API v2.3.
    /// </summary>
    [Optional]
    [JsonPropertyName("read_stream")]
    public bool? ReadStream { get; set; }

    /// <summary>
    /// Grants permission to access a person's age range.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_age_range")]
    public bool? UserAgeRange { get; set; }

    /// <summary>
    /// Grants permission to access a person's birthday.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_birthday")]
    public bool? UserBirthday { get; set; }

    /// <summary>
    /// Grants read-only access to the Events a person is a host of or has RSVPed to. This permission is restricted to a limited set of partners and usage requires prior approval by Facebook.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_events")]
    public bool? UserEvents { get; set; }

    /// <summary>
    /// Grants permission to access a list of friends that also use said app. This permission is restricted to a limited set of partners and usage requires prior approval by Facebook.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_friends")]
    public bool? UserFriends { get; set; }

    /// <summary>
    /// Grants permission to access a person's gender.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_gender")]
    public bool? UserGender { get; set; }

    /// <summary>
    /// Enables your app to read the Groups a person is a member of through the groups edge on the User object. Deprecated in Graph API v2.3.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_groups")]
    public bool? UserGroups { get; set; }

    /// <summary>
    /// Grants permission to access a person's hometown location set in their User Profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_hometown")]
    public bool? UserHometown { get; set; }

    /// <summary>
    /// Grants permission to access the list of all Facebook Pages that a person has liked.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_likes")]
    public bool? UserLikes { get; set; }

    /// <summary>
    /// Grants permission to access the Facebook Profile URL of the user of your app.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_link")]
    public bool? UserLink { get; set; }

    /// <summary>
    /// Provides access to a person's current city through the location field on the User object. The current city is set by a person on their Profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_location")]
    public bool? UserLocation { get; set; }

    /// <summary>
    /// Enables your app to read the Groups a person is an admin of through the groups edge on the User object. Deprecated in Graph API v3.0.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_managed_groups")]
    public bool? UserManagedGroups { get; set; }

    /// <summary>
    /// Provides access to the photos a person has uploaded or been tagged in. This permission is restricted to a limited set of partners and usage requires prior approval by Facebook.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_photos")]
    public bool? UserPhotos { get; set; }

    /// <summary>
    /// Provides access to the posts on a person's Timeline including their own posts, posts they are tagged in, and posts other people make on their Timeline. This permission is restricted to a limited set of partners and usage requires prior approval by Facebook.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_posts")]
    public bool? UserPosts { get; set; }

    /// <summary>
    /// Provides access to a person's statuses. These are posts on Facebook which don't include links, videos or photos. Deprecated in Graph API v2.3.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_status")]
    public bool? UserStatus { get; set; }

    /// <summary>
    /// Provides access to the Places a person has been tagged at in photos, videos, statuses and links. This permission is restricted to a limited set of partners and usage requires prior approval by Facebook.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_tagged_places")]
    public bool? UserTaggedPlaces { get; set; }

    /// <summary>
    /// Provides access to the videos a person has uploaded or been tagged in. This permission is restricted to a limited set of partners and usage requires prior approval by Facebook.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_videos")]
    public bool? UserVideos { get; set; }

    [Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public IEnumerable<string>? NonPersistentAttrs { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
