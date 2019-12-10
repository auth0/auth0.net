using Auth0.Core.Http;
using System;
using System.Collections.Generic;

namespace Auth0.AuthenticationApi.Builders
{
    /// <summary>
    /// Base class for all strongly-typed fluent URL builders.
    /// </summary>
    /// <typeparam name="T">Type of inherited class to faciliate fluent chaining.</typeparam>
    public class UrlBuilderBase<T> where T : UrlBuilderBase<T>
    {
        readonly Uri _baseUrl;
        readonly string _resource;
        readonly IDictionary<string, string> _queryStrings = new Dictionary<string, string>();
        readonly IDictionary<string, string> _urlSegments = new Dictionary<string, string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlBuilderBase{T}"/> class.
        /// </summary>
        /// <param name="baseUrl">Base URL represented as a <see cref="String"/>.</param>
        /// <param name="resource">Resource being accessed.</param>
        /// <exception cref="ArgumentNullException" />
        public UrlBuilderBase(string baseUrl, string resource)
            : this(new Uri(baseUrl), resource)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UrlBuilderBase{T}"/> class.
        /// </summary>
        /// <param name="baseUrl">Base URL represented as a <see cref="Uri"/>.</param>
        /// <param name="resource">Resource being accessed.</param>
        /// <exception cref="ArgumentNullException" />
        public UrlBuilderBase(Uri baseUrl, string resource)
        {
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            _resource = resource ?? throw new ArgumentNullException(nameof(resource));
        }

        /// <summary>
        /// Adds or replaces a URL segment based on name.
        /// </summary>
        /// <remarks>
        /// When specifying the resource, a URL segment can be specified with curly braces. 
        /// For example, the resource can specified as "samlp/{client}". This method
        /// can be used to specify a value for the {client} segment of the resource.
        /// </remarks>
        /// <param name="name">Name of the segment (without the curly braces).</param>
        /// <param name="value">Value the segment should contain.</param>
        protected void AddUrlSegment(string name, string value)
        {
            _urlSegments[name] = value;
        }

        /// <summary>
        /// Adds or replaces a query string parameter.
        /// </summary>
        /// <param name="name">Name of the query string parameter.</param>
        /// <param name="value">Value of the query string parameter.</param>
        protected void AddQueryString(string name, string value)
        {
            _queryStrings[name] = value;
        }

        /// <summary>
        /// Adds an arbitrary query string parameter.
        /// </summary>
        /// <param name="name">Name of the query string parameter.</param>
        /// <param name="value">Value of the query string parameter.</param>
        /// <returns>Current object to allow fluent configuration.</returns>
        public T WithValue(string name, string value)
        {
            AddQueryString(name, value);
            return (T)this;
        }

        /// <summary>
        /// Builds the complete URL based on the values added so far.
        /// </summary>
        /// <returns><see cref="Uri"/> containing the complete URL.</returns>
        public Uri Build()
        {
            return Utils.BuildUri(_baseUrl.OriginalString, _resource, _urlSegments, _queryStrings, true);
        }
    }
}