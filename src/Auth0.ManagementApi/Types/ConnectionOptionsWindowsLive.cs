using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'windowslive' connection
/// </summary>
[Serializable]
public record ConnectionOptionsWindowsLive : IJsonOnDeserialized, IJsonOnSerializing
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
    [JsonPropertyName("scope")]
    public IEnumerable<string>? Scope { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public ConnectionSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    [Optional]
    [JsonPropertyName("strategy_version")]
    public int? StrategyVersion { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("upstream_params")]
    public Optional<Dictionary<
        string,
        ConnectionUpstreamAdditionalProperties?
    >?> UpstreamParams { get; set; }

    /// <summary>
    /// When enabled, requests access to user's applications.
    /// </summary>
    [Optional]
    [JsonPropertyName("applications")]
    public bool? Applications { get; set; }

    /// <summary>
    /// When enabled, requests permission to create applications.
    /// </summary>
    [Optional]
    [JsonPropertyName("applications_create")]
    public bool? ApplicationsCreate { get; set; }

    /// <summary>
    /// When enabled, requests read access to user's basic profile information and contacts list.
    /// </summary>
    [Optional]
    [JsonPropertyName("basic")]
    public bool? Basic { get; set; }

    /// <summary>
    /// When enabled, requests read access to user's birth day, month, and year.
    /// </summary>
    [Optional]
    [JsonPropertyName("birthday")]
    public bool? Birthday { get; set; }

    /// <summary>
    /// When enabled, requests read access to user's calendars and events.
    /// </summary>
    [Optional]
    [JsonPropertyName("calendars")]
    public bool? Calendars { get; set; }

    /// <summary>
    /// When enabled, requests read and write access to user's calendars and events.
    /// </summary>
    [Optional]
    [JsonPropertyName("calendars_update")]
    public bool? CalendarsUpdate { get; set; }

    /// <summary>
    /// When enabled, requests read access to contacts' birth day and birth month.
    /// </summary>
    [Optional]
    [JsonPropertyName("contacts_birthday")]
    public bool? ContactsBirthday { get; set; }

    /// <summary>
    /// When enabled, requests read access to user's calendars and shared calendars/events from others.
    /// </summary>
    [Optional]
    [JsonPropertyName("contacts_calendars")]
    public bool? ContactsCalendars { get; set; }

    /// <summary>
    /// When enabled, requests permission to create new contacts in user's address book.
    /// </summary>
    [Optional]
    [JsonPropertyName("contacts_create")]
    public bool? ContactsCreate { get; set; }

    /// <summary>
    /// When enabled, requests read access to user's and shared albums, photos, videos, and audio.
    /// </summary>
    [Optional]
    [JsonPropertyName("contacts_photos")]
    public bool? ContactsPhotos { get; set; }

    /// <summary>
    /// When enabled, requests read access to OneDrive files shared by other users.
    /// </summary>
    [Optional]
    [JsonPropertyName("contacts_skydrive")]
    public bool? ContactsSkydrive { get; set; }

    /// <summary>
    /// When enabled, allows the app to have the same access to information in the directory as the signed-in user.
    /// </summary>
    [Optional]
    [JsonPropertyName("directory_accessasuser_all")]
    public bool? DirectoryAccessasuserAll { get; set; }

    /// <summary>
    /// When enabled, allows the app to read data in your organization's directory, such as users, groups, and apps.
    /// </summary>
    [Optional]
    [JsonPropertyName("directory_read_all")]
    public bool? DirectoryReadAll { get; set; }

    /// <summary>
    /// When enabled, allows the app to read and write data in your organization's directory, such as users and groups.
    /// </summary>
    [Optional]
    [JsonPropertyName("directory_readwrite_all")]
    public bool? DirectoryReadwriteAll { get; set; }

    /// <summary>
    /// When enabled, requests read access to personal, preferred, and business email addresses.
    /// </summary>
    [Optional]
    [JsonPropertyName("emails")]
    public bool? Emails { get; set; }

    /// <summary>
    /// When enabled, requests permission to create events on user's default calendar.
    /// </summary>
    [Optional]
    [JsonPropertyName("events_create")]
    public bool? EventsCreate { get; set; }

    /// <summary>
    /// When enabled, requests permission to read the user's calendars.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_calendars")]
    public bool? GraphCalendars { get; set; }

    /// <summary>
    /// When enabled, requests permission to read and write the user's calendars.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_calendars_update")]
    public bool? GraphCalendarsUpdate { get; set; }

    /// <summary>
    /// When enabled, requests permission to read the user's contacts.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_contacts")]
    public bool? GraphContacts { get; set; }

    /// <summary>
    /// When enabled, requests permission to read and write the user's contacts.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_contacts_update")]
    public bool? GraphContactsUpdate { get; set; }

    /// <summary>
    /// When enabled, requests permission to read the user's device information.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_device")]
    public bool? GraphDevice { get; set; }

    /// <summary>
    /// When enabled, requests permission to send commands to the user's devices.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_device_command")]
    public bool? GraphDeviceCommand { get; set; }

    /// <summary>
    /// When enabled, requests permission to read the user's emails.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_emails")]
    public bool? GraphEmails { get; set; }

    /// <summary>
    /// When enabled, requests permission to read and write the user's emails.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_emails_update")]
    public bool? GraphEmailsUpdate { get; set; }

    /// <summary>
    /// When enabled, requests permission to read the user's files.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_files")]
    public bool? GraphFiles { get; set; }

    /// <summary>
    /// When enabled, requests permission to read all files the user has access to.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_files_all")]
    public bool? GraphFilesAll { get; set; }

    /// <summary>
    /// When enabled, requests permission to read and write all files the user has access to.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_files_all_update")]
    public bool? GraphFilesAllUpdate { get; set; }

    /// <summary>
    /// When enabled, requests permission to read and write the user's files.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_files_update")]
    public bool? GraphFilesUpdate { get; set; }

    /// <summary>
    /// When enabled, requests permission to read the user's OneNote notebooks.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_notes")]
    public bool? GraphNotes { get; set; }

    /// <summary>
    /// When enabled, requests permission to create new OneNote notebooks.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_notes_create")]
    public bool? GraphNotesCreate { get; set; }

    /// <summary>
    /// When enabled, requests permission to read and write the user's OneNote notebooks.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_notes_update")]
    public bool? GraphNotesUpdate { get; set; }

    /// <summary>
    /// When enabled, requests permission to read the user's tasks.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_tasks")]
    public bool? GraphTasks { get; set; }

    /// <summary>
    /// When enabled, requests permission to read and write the user's tasks.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_tasks_update")]
    public bool? GraphTasksUpdate { get; set; }

    /// <summary>
    /// When enabled, requests permission to read the user's profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_user")]
    public bool? GraphUser { get; set; }

    /// <summary>
    /// When enabled, requests permission to read the user's activity history.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_user_activity")]
    public bool? GraphUserActivity { get; set; }

    /// <summary>
    /// When enabled, requests permission to read and write the user's profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("graph_user_update")]
    public bool? GraphUserUpdate { get; set; }

    /// <summary>
    /// When enabled, allows the app to read all group properties and memberships.
    /// </summary>
    [Optional]
    [JsonPropertyName("group_read_all")]
    public bool? GroupReadAll { get; set; }

    /// <summary>
    /// When enabled, allows the app to create groups, read all group properties and memberships, update group properties and memberships, and delete groups.
    /// </summary>
    [Optional]
    [JsonPropertyName("group_readwrite_all")]
    public bool? GroupReadwriteAll { get; set; }

    /// <summary>
    /// When enabled, allows the app to create, read, update, and delete all mail in all mailboxes.
    /// </summary>
    [Optional]
    [JsonPropertyName("mail_readwrite_all")]
    public bool? MailReadwriteAll { get; set; }

    /// <summary>
    /// When enabled, allows the app to send mail as users in the organization.
    /// </summary>
    [Optional]
    [JsonPropertyName("mail_send")]
    public bool? MailSend { get; set; }

    /// <summary>
    /// When enabled, requests access to user's Windows Live Messenger data.
    /// </summary>
    [Optional]
    [JsonPropertyName("messenger")]
    public bool? Messenger { get; set; }

    /// <summary>
    /// When enabled, requests a refresh token for offline access.
    /// </summary>
    [Optional]
    [JsonPropertyName("offline_access")]
    public bool? OfflineAccess { get; set; }

    /// <summary>
    /// When enabled, requests read access to personal, business, and mobile phone numbers.
    /// </summary>
    [Optional]
    [JsonPropertyName("phone_numbers")]
    public bool? PhoneNumbers { get; set; }

    /// <summary>
    /// When enabled, requests read access to user's photos, videos, audio, and albums.
    /// </summary>
    [Optional]
    [JsonPropertyName("photos")]
    public bool? Photos { get; set; }

    /// <summary>
    /// When enabled, requests read access to personal and business postal addresses.
    /// </summary>
    [Optional]
    [JsonPropertyName("postal_addresses")]
    public bool? PostalAddresses { get; set; }

    /// <summary>
    /// When enabled, allows the app to read the role-based access control (RBAC) settings for your company's directory.
    /// </summary>
    [Optional]
    [JsonPropertyName("rolemanagement_read_all")]
    public bool? RolemanagementReadAll { get; set; }

    /// <summary>
    /// When enabled, allows the app to read and write the role-based access control (RBAC) settings for your company's directory.
    /// </summary>
    [Optional]
    [JsonPropertyName("rolemanagement_readwrite_directory")]
    public bool? RolemanagementReadwriteDirectory { get; set; }

    /// <summary>
    /// When enabled, requests permission to share content with other users.
    /// </summary>
    [Optional]
    [JsonPropertyName("share")]
    public bool? Share { get; set; }

    /// <summary>
    /// When enabled, provides single sign-in behavior for users already signed into their Microsoft account.
    /// </summary>
    [Optional]
    [JsonPropertyName("signin")]
    public bool? Signin { get; set; }

    /// <summary>
    /// When enabled, allows the app to read documents and list items in all SharePoint site collections.
    /// </summary>
    [Optional]
    [JsonPropertyName("sites_read_all")]
    public bool? SitesReadAll { get; set; }

    /// <summary>
    /// When enabled, allows the app to create, read, update, and delete documents and list items in all SharePoint site collections.
    /// </summary>
    [Optional]
    [JsonPropertyName("sites_readwrite_all")]
    public bool? SitesReadwriteAll { get; set; }

    /// <summary>
    /// When enabled, requests read access to user's files stored on OneDrive.
    /// </summary>
    [Optional]
    [JsonPropertyName("skydrive")]
    public bool? Skydrive { get; set; }

    /// <summary>
    /// When enabled, requests read and write access to user's OneDrive files.
    /// </summary>
    [Optional]
    [JsonPropertyName("skydrive_update")]
    public bool? SkydriveUpdate { get; set; }

    /// <summary>
    /// When enabled, allows the app to read the names and descriptions of all teams.
    /// </summary>
    [Optional]
    [JsonPropertyName("team_readbasic_all")]
    public bool? TeamReadbasicAll { get; set; }

    /// <summary>
    /// When enabled, allows the app to read and write all teams' information and change team membership.
    /// </summary>
    [Optional]
    [JsonPropertyName("team_readwrite_all")]
    public bool? TeamReadwriteAll { get; set; }

    /// <summary>
    /// When enabled, allows the app to read the full set of profile properties, reports, and managers of all users.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_read_all")]
    public bool? UserReadAll { get; set; }

    /// <summary>
    /// When enabled, allows the app to read a basic set of profile properties of all users in the directory.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_readbasic_all")]
    public bool? UserReadbasicAll { get; set; }

    /// <summary>
    /// When enabled, requests read access to employer and work position information.
    /// </summary>
    [Optional]
    [JsonPropertyName("work_profile")]
    public bool? WorkProfile { get; set; }

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
