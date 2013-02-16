using System.Collections.Generic;

namespace Auth0
{
    public class ProvisioningTicket
    {
        public string strategy { get; set; }
        public Dictionary<string, string> options { get; set; }
    }
}
