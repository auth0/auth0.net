using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models.Forms
{
    public enum Hydrate
    {
        [EnumMember(Value = "flow_count")]
        FLOW_COUNT,

        [EnumMember(Value = "links")]
        LINKS
    }
}