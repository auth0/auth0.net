using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonFx.Json;
using JsonFx.Serialization;

namespace Auth0.Net
{
    public class Auth0Connection
    {
        public Auth0Connection(string name, string strategy, string tenantDomain)
        {
            Name = name;
            Strategy = strategy;
            Options = new ConnectionOptions { TenantDomain = tenantDomain };
        }

        public Auth0Connection()
        {
            Options = new ConnectionOptions();
        }

        [JsonName("name")]
        public string Name { get; set; }

        [JsonName("strategy")]
        public string Strategy { get; set; }
        
        [JsonName("options")]
        public ConnectionOptions Options { get; set; }
        
        [JsonName("provisioning_ticket")]
        public string ProvisioningTicket { get; set; }

        [JsonName("provisioning_ticket_url")]
        public string ProvisioningTicketUrl { get; set; }

        [JsonName("status")]
        public bool Enabled { get; set; }
    }

    public class ConnectionOptions
    {
        [JsonName("tenant_domain")]
        public string TenantDomain { get; set; }
    }
}
