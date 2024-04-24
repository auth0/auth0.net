using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// The possible types of log stream
    /// </summary>
    public enum LogStreamType
    {
        [EnumMember(Value = "http")]
        Http,

        [EnumMember(Value = "eventbridge")]
        EventBridge,
        
        [EnumMember(Value = "eventgrid")]
        EventGrid,
        
        [EnumMember(Value = "datadog")]
        Datadog,
        
        [EnumMember(Value = "splunk")]
        Splunk,
        
        [EnumMember(Value = "sumo")]
        Sumo,
        
        [EnumMember(Value = "segment")]
        Segment,
        
        [EnumMember(Value = "mixpanel")]
        MixPanel
    }
}
