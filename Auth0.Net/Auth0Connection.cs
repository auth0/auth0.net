using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonFx.Json;

namespace Auth0.Net
{
    public class Auth0Connection
    {
        public string Name { get; set; }
        public string Strategy { get; set; }
        public dynamic Options { get; set; }
        
        [JsonName("provisioning_ticket")]
        public string ProvisioningTicket { get; set; }

        [JsonName("provisioning_ticket_url")]
        public string ProvisioningTicketUrl { get; set; }

        [JsonName("status")]
        public bool Enabled { get; set; }
    }
}
