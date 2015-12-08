using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Auth0.Core.Http;

namespace Auth0.AuthenticationApi.Client.Builders
{
    public class UrlBuilderBase<T> where T : UrlBuilderBase<T>
    {
        private readonly string baseUrl;
        private readonly string resource;
        private readonly IDictionary<string, string> queryStrings = new Dictionary<string, string>();
        private readonly IDictionary<string, string> urlSegments = new Dictionary<string, string>();

        public UrlBuilderBase(string baseUrl, [NotNull] string resource)
        {
            if (baseUrl == null) throw new ArgumentNullException(nameof(baseUrl));
            if (resource == null) throw new ArgumentNullException(nameof(resource));

            this.baseUrl = baseUrl;
            this.resource = resource;
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

        public Uri Build()
        {
            return Utils.BuildUri(baseUrl, resource, urlSegments, queryStrings);
        }
    }
}