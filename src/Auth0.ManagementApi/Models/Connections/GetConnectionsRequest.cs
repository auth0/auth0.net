namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Specifies criteria to use when querying all connections.
    /// </summary>
    public class GetConnectionsRequest
    {
        /// <summary>
        /// A comma separated list of fields to include or exclude (depending on <see cref="IncludeFields"/>) from the result, empty to retrieve all fields.
        /// </summary>
        public string Fields { get; set; } = null;

        /// <summary>
        /// Specifies whether the fields specified in <see cref="Fields"/> should be included or excluded in the result.
        /// </summary>
        public bool? IncludeFields { get; set; } = null;

        /// <summary>
        /// The name of the connection to retrieve.
        /// </summary>
        public string Name { get; set; } = null;

        /// <summary>
        /// Only retrieve connections with these strategies.
        /// </summary>
        public string[] Strategy { get; set; } = null;
    }
}