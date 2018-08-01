using System;
using System.Collections.Concurrent;
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

        private readonly ConcurrentDictionary<string, OpenIdConnectConfiguration> _innerCache = new ConcurrentDictionary<string, OpenIdConnectConfiguration>();

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
            _innerCache.TryGetValue(domain, out var configuration);

            if (configuration == null)
            {
                var uri = new Uri(domain);
                
                IConfigurationManager<OpenIdConnectConfiguration> configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                    $"{uri.Scheme}://{uri.Authority}/.well-known/openid-configuration", new OpenIdConnectConfigurationRetriever());
                configuration = await configurationManager.GetConfigurationAsync(CancellationToken.None);

                _innerCache[domain] = configuration;
            }

            return configuration;
        }
    }
}