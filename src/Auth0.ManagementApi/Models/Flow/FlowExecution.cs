using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Flow;

public class FlowExecution
{
    /// <summary>
    /// Flow execution identifier
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }
        
    /// <summary>
    /// Trace ID
    /// </summary>
    [JsonProperty("trace_id")]
    public string TraceId { get; set; }
        
    /// <summary>
    /// Journey ID
    /// </summary>
    [JsonProperty("journey_id")]
    public string JourneyId { get; set; }
        
    /// <summary>
    /// Execution Status
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }
        
    /// <summary>
    /// Flow execution debug.
    /// </summary>
    [JsonProperty("debug")]
    public dynamic Debug { get; set; }
        
    /// <summary>
    /// The ISO 8601 formatted date when this flow execution was created.
    /// </summary>
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }
        
    /// <summary>
    /// The ISO 8601 formatted date when this flow execution was updated.
    /// </summary>
    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
        
    /// <summary>
    /// The ISO 8601 formatted date when this flow execution started.
    /// </summary>
    [JsonProperty("started_at")]
    public DateTime? StartedAt { get; set; }
        
    /// <summary>
    /// The ISO 8601 formatted date when this flow execution ended.
    /// </summary>
    [JsonProperty("ended_at")]
    public DateTime? EndedAt { get; set; }
}