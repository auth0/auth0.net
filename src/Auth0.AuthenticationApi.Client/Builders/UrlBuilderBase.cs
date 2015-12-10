using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Auth0.Core.Http;

namespace Auth0.AuthenticationApi.Client.Builders
{
    /// <summary>
    /// The base class for all URL builders.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class UrlBuilderBase<T> where T : UrlBuilderBase<T>
    {
        private readonly string baseUrl;
        private readonly string resource;
        private readonly IDictionary<string, string> queryStrings = new Dictionary<string, string>();
        private readonly IDictionary<string, string> urlSegments = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlBuilderBase{T}"/> class.
        /// </summary>
        /// <param name="baseUrl">The base URL.</param>
        /// <param name="resource">The resource being accessed.</param>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        public UrlBuilderBase(string baseUrl, [NotNull] string resource)
        {
            if (baseUrl == null) throw new ArgumentNullException(nameof(baseUrl));
            if (resource == null) throw new ArgumentNullException(nameof(resource));

            this.baseUrl = baseUrl;
            this.resource = resource;
        }

        /// <summary>
        /// Adds a new URL segment.
        /// </summary>
        /// <remarks>
        /// When specifying the resource, a URL segment can be specified with curly braces. For example, the resource can specified as "samlp/{client}". This method
        /// can be used to specify a value for the {client} segment of the resource.
        /// </remarks>
        /// <param name="name">The name of the segment (without the curly braces).</param>
        /// <param name="value">The value of the segment.</param>
        protected void AddUrlSegment(string name, string value)
        {
            urlSegments[name] = value;
        }

        /// <summary>
        /// Adds the query string parameter to the URL.
        /// </summary>
        /// <param name="name">The name of the query string parameter.</param>
        /// <param name="value">The value of the query string parameter.</param>
        protected void AddQueryString(string name, string value)
        {
            queryStrings[name] = value;
        }

        /// <summary>
        /// Adds an arbitrary query string parameter to the URL.
        /// </summary>
        /// <param name="name">The name of the query string parameter.</param>
        /// <param name="value">The value of the query string parameter.</param>
        /// <returns>T.</returns>
        public T WithValue(string name, string value)
        {
            AddQueryString(name, value);

            return (T) this;
        }

        /// <summary>
        /// Builds the URL.
        /// </summary>
        /// <returns>A <see cref="Uri"/> with the URL.</returns>
        public Uri Build()
        {
            return Utils.BuildUri(baseUrl, resource, urlSegments, queryStrings);
        }
    }
}