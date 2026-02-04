using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'google-oauth2' connection
/// </summary>
[Serializable]
public record ConnectionOptionsGoogleOAuth2 : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// View and manage user's ad applications, ad units, and channels in AdSense
    /// </summary>
    [Optional]
    [JsonPropertyName("adsense_management")]
    public bool? AdsenseManagement { get; set; }

    [Optional]
    [JsonPropertyName("allowed_audiences")]
    public IEnumerable<string>? AllowedAudiences { get; set; }

    /// <summary>
    /// View user's configuration information and reports
    /// </summary>
    [Optional]
    [JsonPropertyName("analytics")]
    public bool? Analytics { get; set; }

    /// <summary>
    /// View and manage user's posts and blogs on Blogger and Blogger comments
    /// </summary>
    [Optional]
    [JsonPropertyName("blogger")]
    public bool? Blogger { get; set; }

    /// <summary>
    /// See, edit, share, and permanently delete all the calendars you can access using Google Calendar
    /// </summary>
    [Optional]
    [JsonPropertyName("calendar")]
    public bool? Calendar { get; set; }

    /// <summary>
    /// Run as a Calendar add-on
    /// </summary>
    [Optional]
    [JsonPropertyName("calendar_addons_execute")]
    public bool? CalendarAddonsExecute { get; set; }

    /// <summary>
    /// View and edit events on all your calendars
    /// </summary>
    [Optional]
    [JsonPropertyName("calendar_events")]
    public bool? CalendarEvents { get; set; }

    /// <summary>
    /// View events on all your calendars
    /// </summary>
    [Optional]
    [JsonPropertyName("calendar_events_readonly")]
    public bool? CalendarEventsReadonly { get; set; }

    /// <summary>
    /// View your Calendar settings
    /// </summary>
    [Optional]
    [JsonPropertyName("calendar_settings_readonly")]
    public bool? CalendarSettingsReadonly { get; set; }

    /// <summary>
    /// Read access to user's chrome web store
    /// </summary>
    [Optional]
    [JsonPropertyName("chrome_web_store")]
    public bool? ChromeWebStore { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("client_id")]
    public Optional<string?> ClientId { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("client_secret")]
    public Optional<string?> ClientSecret { get; set; }

    /// <summary>
    /// Full access to the authenticated user's contacts
    /// </summary>
    [Optional]
    [JsonPropertyName("contacts")]
    public bool? Contacts { get; set; }

    /// <summary>
    /// Full access to the authenticated user's contacts
    /// </summary>
    [Optional]
    [JsonPropertyName("contacts_new")]
    public bool? ContactsNew { get; set; }

    /// <summary>
    /// Read-only access to the authenticated user's 'Other contacts'
    /// </summary>
    [Optional]
    [JsonPropertyName("contacts_other_readonly")]
    public bool? ContactsOtherReadonly { get; set; }

    /// <summary>
    /// Read-only access to the authenticated user's contacts
    /// </summary>
    [Optional]
    [JsonPropertyName("contacts_readonly")]
    public bool? ContactsReadonly { get; set; }

    /// <summary>
    /// View and manage user's products, feeds, and subaccounts
    /// </summary>
    [Optional]
    [JsonPropertyName("content_api_for_shopping")]
    public bool? ContentApiForShopping { get; set; }

    /// <summary>
    /// Grants read and write access to the Coordinate API
    /// </summary>
    [Optional]
    [JsonPropertyName("coordinate")]
    public bool? Coordinate { get; set; }

    /// <summary>
    /// Grants read access to the Coordinate API
    /// </summary>
    [Optional]
    [JsonPropertyName("coordinate_readonly")]
    public bool? CoordinateReadonly { get; set; }

    /// <summary>
    /// Read-only access to the authenticated user's corporate directory (if applicable)
    /// </summary>
    [Optional]
    [JsonPropertyName("directory_readonly")]
    public bool? DirectoryReadonly { get; set; }

    /// <summary>
    /// Access to Google Docs document list feed
    /// </summary>
    [Optional]
    [JsonPropertyName("document_list")]
    public bool? DocumentList { get; set; }

    /// <summary>
    /// Full access to all files and folders in the user's Google Drive
    /// </summary>
    [Optional]
    [JsonPropertyName("drive")]
    public bool? Drive { get; set; }

    /// <summary>
    /// View and add to the activity record of files in your Drive
    /// </summary>
    [Optional]
    [JsonPropertyName("drive_activity")]
    public bool? DriveActivity { get; set; }

    /// <summary>
    /// View the activity record of files in your Drive
    /// </summary>
    [Optional]
    [JsonPropertyName("drive_activity_readonly")]
    public bool? DriveActivityReadonly { get; set; }

    /// <summary>
    /// Access to the application's configuration data in the user's Google Drive
    /// </summary>
    [Optional]
    [JsonPropertyName("drive_appdata")]
    public bool? DriveAppdata { get; set; }

    /// <summary>
    /// View apps authorized to access your Drive
    /// </summary>
    [Optional]
    [JsonPropertyName("drive_apps_readonly")]
    public bool? DriveAppsReadonly { get; set; }

    /// <summary>
    /// Access to files created or opened by the app
    /// </summary>
    [Optional]
    [JsonPropertyName("drive_file")]
    public bool? DriveFile { get; set; }

    /// <summary>
    /// Access to file metadata, including listing files and folders
    /// </summary>
    [Optional]
    [JsonPropertyName("drive_metadata")]
    public bool? DriveMetadata { get; set; }

    /// <summary>
    /// Read-only access to file metadata
    /// </summary>
    [Optional]
    [JsonPropertyName("drive_metadata_readonly")]
    public bool? DriveMetadataReadonly { get; set; }

    /// <summary>
    /// Read-only access to the user's Google Photos
    /// </summary>
    [Optional]
    [JsonPropertyName("drive_photos_readonly")]
    public bool? DrivePhotosReadonly { get; set; }

    /// <summary>
    /// Read-only access to all files and folders in the user's Google Drive
    /// </summary>
    [Optional]
    [JsonPropertyName("drive_readonly")]
    public bool? DriveReadonly { get; set; }

    /// <summary>
    /// Modify the behavior of Google Apps Scripts
    /// </summary>
    [Optional]
    [JsonPropertyName("drive_scripts")]
    public bool? DriveScripts { get; set; }

    /// <summary>
    /// Email and verified email flag
    /// </summary>
    [Optional]
    [JsonPropertyName("email")]
    public bool? Email { get; set; }

    [Optional]
    [JsonPropertyName("freeform_scopes")]
    public IEnumerable<string>? FreeformScopes { get; set; }

    /// <summary>
    /// Full access to the account's mailboxes, including permanent deletion of threads and messages
    /// </summary>
    [Optional]
    [JsonPropertyName("gmail")]
    public bool? Gmail { get; set; }

    /// <summary>
    /// Read all resources and their metadata—no write operations
    /// </summary>
    [Optional]
    [JsonPropertyName("gmail_compose")]
    public bool? GmailCompose { get; set; }

    /// <summary>
    /// Insert and import messages only
    /// </summary>
    [Optional]
    [JsonPropertyName("gmail_insert")]
    public bool? GmailInsert { get; set; }

    /// <summary>
    /// Create, read, update, and delete labels only
    /// </summary>
    [Optional]
    [JsonPropertyName("gmail_labels")]
    public bool? GmailLabels { get; set; }

    /// <summary>
    /// Read resources metadata including labels, history records, and email message headers, but not the message body or attachments
    /// </summary>
    [Optional]
    [JsonPropertyName("gmail_metadata")]
    public bool? GmailMetadata { get; set; }

    /// <summary>
    /// All read/write operations except immediate, permanent deletion of threads and messages, bypassing Trash
    /// </summary>
    [Optional]
    [JsonPropertyName("gmail_modify")]
    public bool? GmailModify { get; set; }

    /// <summary>
    /// Full access to the account's mailboxes, including permanent deletion of threads and messages
    /// </summary>
    [Optional]
    [JsonPropertyName("gmail_new")]
    public bool? GmailNew { get; set; }

    /// <summary>
    /// Read all resources and their metadata—no write operations
    /// </summary>
    [Optional]
    [JsonPropertyName("gmail_readonly")]
    public bool? GmailReadonly { get; set; }

    /// <summary>
    /// Send messages only. No read or modify privileges on mailbox
    /// </summary>
    [Optional]
    [JsonPropertyName("gmail_send")]
    public bool? GmailSend { get; set; }

    /// <summary>
    /// Manage basic mail settings
    /// </summary>
    [Optional]
    [JsonPropertyName("gmail_settings_basic")]
    public bool? GmailSettingsBasic { get; set; }

    /// <summary>
    /// Manage sensitive mail settings, including forwarding rules and aliases. Note: Operations guarded by this scope are restricted to administrative use only
    /// </summary>
    [Optional]
    [JsonPropertyName("gmail_settings_sharing")]
    public bool? GmailSettingsSharing { get; set; }

    /// <summary>
    /// View and manage user's publisher data in the Google Affiliate Network
    /// </summary>
    [Optional]
    [JsonPropertyName("google_affiliate_network")]
    public bool? GoogleAffiliateNetwork { get; set; }

    /// <summary>
    /// View and manage user's books and library in Google Books
    /// </summary>
    [Optional]
    [JsonPropertyName("google_books")]
    public bool? GoogleBooks { get; set; }

    /// <summary>
    /// View and manage user's data stored in Google Cloud Storage
    /// </summary>
    [Optional]
    [JsonPropertyName("google_cloud_storage")]
    public bool? GoogleCloudStorage { get; set; }

    /// <summary>
    /// Full access to all files and folders in the user's Google Drive
    /// </summary>
    [Optional]
    [JsonPropertyName("google_drive")]
    public bool? GoogleDrive { get; set; }

    /// <summary>
    /// Access to files created or opened by the app
    /// </summary>
    [Optional]
    [JsonPropertyName("google_drive_files")]
    public bool? GoogleDriveFiles { get; set; }

    /// <summary>
    /// Associate user with its public Google profile
    /// </summary>
    [Optional]
    [JsonPropertyName("google_plus")]
    public bool? GooglePlus { get; set; }

    [Optional]
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }

    /// <summary>
    /// View and manage user's best-available current location and location history in Google Latitude
    /// </summary>
    [Optional]
    [JsonPropertyName("latitude_best")]
    public bool? LatitudeBest { get; set; }

    /// <summary>
    /// View and manage user's city-level current location and location history in Google Latitude
    /// </summary>
    [Optional]
    [JsonPropertyName("latitude_city")]
    public bool? LatitudeCity { get; set; }

    /// <summary>
    /// View and manage user's votes, topics, and submissions
    /// </summary>
    [Optional]
    [JsonPropertyName("moderator")]
    public bool? Moderator { get; set; }

    /// <summary>
    /// Request a refresh token when the user authorizes your application
    /// </summary>
    [Optional]
    [JsonPropertyName("offline_access")]
    public bool? OfflineAccess { get; set; }

    /// <summary>
    /// View and manage user's friends, applications and profile and status
    /// </summary>
    [Optional]
    [JsonPropertyName("orkut")]
    public bool? Orkut { get; set; }

    /// <summary>
    /// View and manage user's Google photos, videos, photo and video tags and comments
    /// </summary>
    [Optional]
    [JsonPropertyName("picasa_web")]
    public bool? PicasaWeb { get; set; }

    /// <summary>
    /// Name, public profile URL, photo, country, language, and timezone
    /// </summary>
    [Optional]
    [JsonPropertyName("profile")]
    public bool? Profile { get; set; }

    [Optional]
    [JsonPropertyName("scope")]
    public IEnumerable<string>? Scope { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public ConnectionSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    /// <summary>
    /// View and manage user's sites on Google Sites
    /// </summary>
    [Optional]
    [JsonPropertyName("sites")]
    public bool? Sites { get; set; }

    /// <summary>
    /// Full access to create, edit, organize, and delete all your tasks
    /// </summary>
    [Optional]
    [JsonPropertyName("tasks")]
    public bool? Tasks { get; set; }

    /// <summary>
    /// Read-only access to view your tasks and task lists
    /// </summary>
    [Optional]
    [JsonPropertyName("tasks_readonly")]
    public bool? TasksReadonly { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("upstream_params")]
    public Optional<Dictionary<
        string,
        ConnectionUpstreamAdditionalProperties?
    >?> UpstreamParams { get; set; }

    /// <summary>
    /// View, manage and view statistics user's short URLs
    /// </summary>
    [Optional]
    [JsonPropertyName("url_shortener")]
    public bool? UrlShortener { get; set; }

    /// <summary>
    /// View and manage user's sites and messages, view keywords
    /// </summary>
    [Optional]
    [JsonPropertyName("webmaster_tools")]
    public bool? WebmasterTools { get; set; }

    /// <summary>
    /// Manage your YouTube account
    /// </summary>
    [Optional]
    [JsonPropertyName("youtube")]
    public bool? Youtube { get; set; }

    /// <summary>
    /// See a list of your current active channel members, their current level, and when they became a member
    /// </summary>
    [Optional]
    [JsonPropertyName("youtube_channelmemberships_creator")]
    public bool? YoutubeChannelmembershipsCreator { get; set; }

    /// <summary>
    /// Manage your YouTube account
    /// </summary>
    [Optional]
    [JsonPropertyName("youtube_new")]
    public bool? YoutubeNew { get; set; }

    /// <summary>
    /// View your YouTube account
    /// </summary>
    [Optional]
    [JsonPropertyName("youtube_readonly")]
    public bool? YoutubeReadonly { get; set; }

    /// <summary>
    /// Manage your YouTube videos
    /// </summary>
    [Optional]
    [JsonPropertyName("youtube_upload")]
    public bool? YoutubeUpload { get; set; }

    /// <summary>
    /// View and manage your assets and associated content on YouTube
    /// </summary>
    [Optional]
    [JsonPropertyName("youtubepartner")]
    public bool? Youtubepartner { get; set; }

    [Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public IEnumerable<string>? NonPersistentAttrs { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
