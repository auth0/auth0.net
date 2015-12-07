using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Auth0.AuthenticationApi.Client
{
    public class UrlBuilderBase<T> where T : UrlBuilderBase<T>
    {
        private readonly string baseUrl;
        private readonly IDictionary<string, string> queryStrings = new Dictionary<string, string>();
        private readonly IDictionary<string, string> urlSegments = new Dictionary<string, string>();

        public UrlBuilderBase([NotNull] string baseUrl)
        {
            if (baseUrl == null) throw new ArgumentNullException(nameof(baseUrl));

            this.baseUrl = baseUrl;
        }

        protected void AddUrlSegment(string name, string value)
        {
            urlSegments[name] = value;
        }

        protected void AddQueryString(string name, string value)
        {
            queryStrings[name] = value;
        }

        public T WithValue(string name, string value)
        {
            AddQueryString(name, value);

            return (T) this;
        }
    }

    public class SamlUrlBuilder : UrlBuilderBase<SamlUrlBuilder>
    {
        private string ConnectionName { get; set; }

        public SamlUrlBuilder(string baseUrl, string client)
            :base(baseUrl)
        {
            AddUrlSegment("client", client);
        }

        public SamlUrlBuilder WithConnection(string connectionName)
        {
            AddQueryString("connectionName", connectionName);

            return this;
        }
    }
}