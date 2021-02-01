namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Specifies criteria to use when querying all users.
    /// </summary>
    public class GetUsersRequest
    {
        /// <summary>
        /// Connection filter. Only applies when <see cref="SearchEngine"/> is set to v1. 
        /// To filter by connection with <see cref="SearchEngine"/> set to v2 or v3, set <see cref="Query"/> to identities.connection:"connection_name" instead.
        /// </summary>
        public string Connection { get; set; } = null;

        /// <summary>
        /// A comma separated list of fields to include or exclude (depending on <see cref="IncludeFields"/>) from the result, empty to retrieve all fields.
        /// </summary>
        public string Fields { get; set; } = null;

        /// <summary>
        /// Specifies whether the fields specified in <see cref="Fields"/> should be included or excluded in the result.
        /// </summary>
        public bool? IncludeFields { get; set; } = null;

        /// <summary>
        /// Query in Lucene query string syntax.
        /// </summary>
        /// <remarks>
        /// Not all metadata fields are searchable when using search engine v2. When using search engine v3, some query types cannot be used on metadata fields.
        /// </remarks>
        public string Query { get; set; } = null;

        /// <summary>
        /// The version of the search engine to use.
        /// </summary>
        /// <remarks>
        /// Will default to v2 if no value is passed. Default will change to v3 on 2018/11/13.
        /// For more info <a href="https://auth0.com/docs/users/search/v3#migrate-from-search-engine-v2-to-v3">see the online documentation</a>.
        /// </remarks>
        public string SearchEngine { get; set; } = null;

        /// <summary>
        /// The field to use for sorting. 1 == ascending and -1 == descending.
        /// </summary>
        public string Sort { get; set; } = null;
    }
}
