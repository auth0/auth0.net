using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models.Actions;

public class ActionSupportedTrigger
{
    /// <summary>
    /// The actions extensibility point
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// The version of a trigger. v1, v2, etc.
    /// </summary>
    [JsonProperty("version")]
    public string Version { get; set; }
        
    /// <summary>
    /// Points to the trigger status.
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }
        
    /// <summary>
    /// Runtimes supported by the trigger.
    /// </summary>
    [JsonProperty("runtimes")]
    public string[] Runtimes { get; set; }
        
    /// <summary>
    /// Runtime that will be used when none is specified when creating an action.
    /// </summary>
    [JsonProperty("default_runtime")]
    public string DefaultRuntime { get; set; }
        
    /// <inheritdoc cref="Auth0.ManagementApi.Models.Actions.CompatibleTrigger"/>
    [JsonProperty("compatible_triggers")]
    public IList<CompatibleTrigger> CompatibleTrigger { get; set; }
        
    ///  <inheritdoc cref="Auth0.ManagementApi.Models.Actions.BindingPolicy"/>
    [JsonProperty("binding_policy")]
    [JsonConverter(typeof(StringEnumConverter))]
    public BindingPolicy BindingPolicy { get; set; }
}