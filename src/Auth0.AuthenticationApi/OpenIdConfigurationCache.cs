using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Auth0.AuthenticationApi
{
    internal class OpenIdConfigurationCache
    {
        private static volatile OpenIdConfigurationCache _instance;
        private static readonly object SyncRoot = new object();

        protected ReaderWriterLockSlim CacheLock = new ReaderWriterLockSlim(); // mutex 
        protected Dictionary<string, OpenIdConnectConfiguration> InnerCache = new Dictionary<string, OpenIdConnectConfiguration>();

        private OpenIdConfigurationCache() {}

        public static OpenIdConfigurationCache Instance
        {
            get 
            {
                if (_instance == null) 
                {
                    lock (SyncRoot) 
                    {
                        if (_instance == null) 
                            _instance = new OpenIdConfigurationCache();
                    }
                }

                return _instance;
            }
        }

        public async Task<OpenIdConnectConfiguration> GetAsync(string domain)
        {
            CacheLock.EnterReadLock();
            try
            {
                InnerCache.TryGetValue(domain, out var configuration);

                if (configuration == null)
                {
                    IConfigurationManager<OpenIdConnectConfiguration> configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>($"{domain}.well-known/openid-configuration", new OpenIdConnectConfigurationRetriever());
                    configuration = await configurationManager.GetConfigurationAsync(CancellationToken.None);

                    InnerCache[domain] = configuration;
                }

                return configuration;
            }
            finally
            {
                CacheLock.ExitReadLock();
            }
        }
    }
}