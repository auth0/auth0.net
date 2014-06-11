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
            if (strategy == null) throw new ArgumentNullException("strategy");
            if (tenantDomain == null) throw new ArgumentNullException("tenantDomain");
            Name = string.IsNullOrEmpty(name) ? tenantDomain : name;
            Strategy = strategy;
            Options = new ConnectionOptions { TenantDomain = tenantDomain };
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

    public class ConnectionOptions
    {
        public ConnectionOptions()
        {
            this.ExtraProperties = new Dictionary<string, object>();
        }

        [JsonProperty(PropertyName = "tenant_domain")]
        public string TenantDomain { get; set; }

        [JsonProperty(PropertyName = "adfs_server")]
        public string AdfsServer { get; set; }

        [JsonProperty(PropertyName = "server_url")]
        public string ServerUrl { get; set; }

        [JsonProperty(PropertyName = "entityId")]
        public string EntityId { get; set; }

        public IDictionary<string, object> ExtraProperties { get; set; }
    }
}