using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Addons enabled for this client and their associated configurations.
/// </summary>
[Serializable]
public record ClientAddons : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("aws")]
    public ClientAddonAws? Aws { get; set; }

    [Optional]
    [JsonPropertyName("azure_blob")]
    public ClientAddonAzureBlob? AzureBlob { get; set; }

    [Optional]
    [JsonPropertyName("azure_sb")]
    public ClientAddonAzureSb? AzureSb { get; set; }

    [Optional]
    [JsonPropertyName("rms")]
    public ClientAddonRms? Rms { get; set; }

    [Optional]
    [JsonPropertyName("mscrm")]
    public ClientAddonMscrm? Mscrm { get; set; }

    [Optional]
    [JsonPropertyName("slack")]
    public ClientAddonSlack? Slack { get; set; }

    [Optional]
    [JsonPropertyName("sentry")]
    public ClientAddonSentry? Sentry { get; set; }

    [Optional]
    [JsonPropertyName("box")]
    public Dictionary<string, object?>? Box { get; set; }

    [Optional]
    [JsonPropertyName("cloudbees")]
    public Dictionary<string, object?>? Cloudbees { get; set; }

    [Optional]
    [JsonPropertyName("concur")]
    public Dictionary<string, object?>? Concur { get; set; }

    [Optional]
    [JsonPropertyName("dropbox")]
    public Dictionary<string, object?>? Dropbox { get; set; }

    [Optional]
    [JsonPropertyName("echosign")]
    public ClientAddonEchoSign? Echosign { get; set; }

    [Optional]
    [JsonPropertyName("egnyte")]
    public ClientAddonEgnyte? Egnyte { get; set; }

    [Optional]
    [JsonPropertyName("firebase")]
    public ClientAddonFirebase? Firebase { get; set; }

    [Optional]
    [JsonPropertyName("newrelic")]
    public ClientAddonNewRelic? Newrelic { get; set; }

    [Optional]
    [JsonPropertyName("office365")]
    public ClientAddonOffice365? Office365 { get; set; }

    [Optional]
    [JsonPropertyName("salesforce")]
    public ClientAddonSalesforce? Salesforce { get; set; }

    [Optional]
    [JsonPropertyName("salesforce_api")]
    public ClientAddonSalesforceApi? SalesforceApi { get; set; }

    [Optional]
    [JsonPropertyName("salesforce_sandbox_api")]
    public ClientAddonSalesforceSandboxApi? SalesforceSandboxApi { get; set; }

    [Optional]
    [JsonPropertyName("samlp")]
    public ClientAddonSaml? Samlp { get; set; }

    [Optional]
    [JsonPropertyName("layer")]
    public ClientAddonLayer? Layer { get; set; }

    [Optional]
    [JsonPropertyName("sap_api")]
    public ClientAddonSapapi? SapApi { get; set; }

    [Optional]
    [JsonPropertyName("sharepoint")]
    public ClientAddonSharePoint? Sharepoint { get; set; }

    [Optional]
    [JsonPropertyName("springcm")]
    public ClientAddonSpringCm? Springcm { get; set; }

    [Optional]
    [JsonPropertyName("wams")]
    public ClientAddonWams? Wams { get; set; }

    [Optional]
    [JsonPropertyName("wsfed")]
    public Dictionary<string, object?>? Wsfed { get; set; }

    [Optional]
    [JsonPropertyName("zendesk")]
    public ClientAddonZendesk? Zendesk { get; set; }

    [Optional]
    [JsonPropertyName("zoom")]
    public ClientAddonZoom? Zoom { get; set; }

    [Optional]
    [JsonPropertyName("sso_integration")]
    public ClientAddonSsoIntegration? SsoIntegration { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("oag")]
    public Optional<ClientAddonOag?> Oag { get; set; }

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
