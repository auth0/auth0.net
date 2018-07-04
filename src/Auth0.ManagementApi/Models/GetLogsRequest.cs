namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Specifies criteria to use when querying all logs.
    /// </summary>
    public class GetLogsRequest
    {
        /// <summary>
        /// A comma separated list of fields to include or exclude (depending on <see cref="IncludeFields"/>) from the result.
        /// </summary>
        public string Fields { get; set; } = null;

        /// <summary>
        /// Log Event Id to start retrieving logs. You can limit the amount of logs using the <see cref="Take"/> parameter.
        /// </summary>
        public string From { get; set; } = null;

        /// <summary>
        /// Specifies whether the fields specified in <see cref="Fields"/> should be included or excluded in the result.
        /// </summary>
        public bool? IncludeFields { get; set; } = null;

        /// <summary>
        /// Query in Lucene query string syntax.
        /// </summary>
        public string Query { get; set; } = null;

        /// <summary>
        /// The field to use for sorting. Use field:order where order is 1 for ascending and -1 for descending.
        /// </summary>
        /// <remarks>e.g. date:-1</remarks>
        public string Sort { get; set; } = null;

        /// <summary>
        /// The total amount of entries to retrieve when using the <see cref="From"/> parameter. Default: 50. Max value: 100
        /// </summary>
        public int? Take { get; set; } = null;
    }
}