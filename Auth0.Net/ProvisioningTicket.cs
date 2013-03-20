using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Auth0
{
    [DataContract]
    public class ProvisioningTicket
    {
        public string strategy { get; set; }
        public Dictionary<string, string> options { get; set; }
    }
}
