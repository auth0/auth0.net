using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Auth0
{
    [JsonObject]
    public class Connection
    {
        public Connection(string strategy, string tenantDomain, string name = null)
        {
            if (strategy == null)
            {
                throw new ArgumentNullException("strategy");
            }

            if (tenantDomain == null)
            {
                throw new ArgumentNullException("tenantDomain");
            }

            Name = string.IsNullOrEmpty(name) ? tenantDomain : name;
            Strategy = strategy;
            Options = new ConnectionOptions(tenantDomain);
            Enabled = true;
        }

        public Connection()
        {
            Options = new ConnectionOptions();
        }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "strategy")]
        public string Strategy { get; set; }

        [JsonProperty(PropertyName = "options")]
        public ConnectionOptions Options { get; set; }

        [JsonProperty(PropertyName = "provisioning_ticket")]
        public string ProvisioningTicket { get; set; }

        [JsonProperty(PropertyName = "provisioning_ticket_url")]
        public string ProvisioningTicketUrl { get; set; }

        [JsonProperty(PropertyName = "status")]
        public bool Enabled { get; set; }
    }

    public class ConnectionOptions : Dictionary<string, object>
    {
        public ConnectionOptions() : this(string.Empty)
        {
        }

        public ConnectionOptions(string tenantDomain)
        {
            this.Add("tenant_domain", tenantDomain);
        }
    }
}