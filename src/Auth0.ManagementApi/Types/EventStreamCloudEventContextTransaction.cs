using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// An auth transaction.
/// </summary>
[Serializable]
public record EventStreamCloudEventContextTransaction : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// acr_values in the request.
    /// </summary>
    [JsonPropertyName("acr_values")]
    public IEnumerable<string> AcrValues { get; set; } = new List<string>();

    /// <summary>
    /// The locale used for this transaction.
    /// </summary>
    [JsonPropertyName("locale")]
    public required string Locale { get; set; }

    /// <summary>
    /// Hint about the login identifier the user might use in this transaction.
    /// </summary>
    [Optional]
    [JsonPropertyName("login_hint")]
    public string? LoginHint { get; set; }

    /// <summary>
    /// Instructions indicating whether the user may be prompted for re-authentication and consent.
    /// </summary>
    [Optional]
    [JsonPropertyName("prompt")]
    public IEnumerable<string>? Prompt { get; set; }

    [Optional]
    [JsonPropertyName("protocol")]
    public EventStreamCloudEventContextTransactionProtocolEnum? Protocol { get; set; }

    /// <summary>
    /// The URL to which the client will be redirected when the transaction completes.
    /// </summary>
    [Optional]
    [JsonPropertyName("redirect_uri")]
    public string? RedirectUri { get; set; }

    /// <summary>
    /// The scopes requested.
    /// </summary>
    [JsonPropertyName("requested_scopes")]
    public IEnumerable<string> RequestedScopes { get; set; } = new List<string>();

    [Optional]
    [JsonPropertyName("response_mode")]
    public EventStreamCloudEventContextTransactionResponseModeEnum? ResponseMode { get; set; }

    /// <summary>
    /// The kind of credential issued by this transaction.
    /// </summary>
    [Optional]
    [JsonPropertyName("response_type")]
    public IEnumerable<EventStreamCloudEventContextTransactionResponseTypeItemEnum>? ResponseType { get; set; }

    /// <summary>
    /// The OAuth state parameter for this transaction.
    /// </summary>
    [Optional]
    [JsonPropertyName("state")]
    public string? State { get; set; }

    /// <summary>
    /// The ui_locales requested for this transaction.
    /// </summary>
    [JsonPropertyName("ui_locales")]
    public IEnumerable<string> UiLocales { get; set; } = new List<string>();

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
