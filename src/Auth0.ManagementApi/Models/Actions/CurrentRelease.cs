using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Actions;

public class CurrentRelease
{
    /// <summary>
    /// Id of the associated IntegrationRelease.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }
        
    /// <inheritdoc cref="Auth0.ManagementApi.Models.Actions.Trigger"/>
    [JsonProperty("trigger")]
    public Trigger Trigger { get; set; }
        
    /// <inheritdoc cref="Auth0.ManagementApi.Models.Actions.ActionSemVer"/>
    [JsonProperty("semver")]
    public ActionSemVer SemVer { get; set; }
        
    /// <inheritdoc cref="Auth0.ManagementApi.Models.Actions.ActionsRequiredSecrets"/>
    [JsonProperty("required_secrets")]
    public IList<ActionsRequiredSecrets> RequiredSecrets { get; set; }
        
    /// <inheritdoc cref="Auth0.ManagementApi.Models.Actions.ActionsRequiredConfiguration"/>
    [JsonProperty("required_configuration")]
    public IList<ActionsRequiredConfiguration> RequiredConfigurations { get; set; }
}