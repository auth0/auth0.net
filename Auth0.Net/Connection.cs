using System;

namespace Auth0
{
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

        public string Name { get; set; }

        public string Strategy { get; set; }
        
        public ConnectionOptions Options { get; set; }
        
        public string ProvisioningTicket { get; set; }

        public string ProvisioningTicketUrl { get; set; }

        public bool Enabled { get; set; }
    }

    public class ConnectionOptions
    {
        public string TenantDomain { get; set; }

        public string AdfsServer { get; set; }
    }
}
