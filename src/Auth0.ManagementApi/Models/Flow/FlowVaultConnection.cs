using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Flow;

public class FlowVaultConnection
{
    /// <summary>
    /// Flows Vault Connection identifier.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }
        
    /// <summary>
    /// Flows Vault Connection app identifier.
    /// </summary>
    [JsonProperty("app_id")]
    public string AppId { get; set; }
        
    /// <summary>
    /// Flows Vault Connection name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
        
    /// <summary>
    /// Flows Vault Connection custom account name.
    /// </summary>
    [JsonProperty("account_name")]
    public string AccountName { get; set; }
        
    /// <summary>
    /// Whether the Flows Vault Connection is configured.
    /// </summary>
    [JsonProperty("ready")]
    public bool? Ready { get; set; }
        
    /// <summary>
    /// The ISO 8601 formatted date when this Flows Vault Connection was created.
    /// </summary>
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }
        
    /// <summary>
    /// The ISO 8601 formatted date when this Flows Vault Connection was updated.
    /// </summary>
    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
        
    /// <summary>
    /// The ISO 8601 formatted date when this Flows Vault Connection was refreshed.
    /// </summary>
    [JsonProperty("refreshed_at")]
    public DateTime? RefreshedAt { get; set; }
        
    [JsonProperty("fingerprint")]
    public string Fingerprint { get; set; }
}