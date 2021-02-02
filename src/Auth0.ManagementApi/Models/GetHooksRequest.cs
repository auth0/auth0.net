namespace Auth0.ManagementApi.Models
{
    public class GetHooksRequest
    {
        /// <summary>
        /// If provided retrieves hooks that match the value, otherwise all rules are retrieved.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// A comma separated list of fields to include or exclude (depending on <see cref="IncludeFields"/>) from the result, empty to retrieve all fields.
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// True if the fields specified are to be included in the result, false otherwise.
        /// </summary>
        /// <remarks>
        /// Defaults to true.
        /// </remarks>
        public bool? IncludeFields { get; set; }

        /// <summary>
        /// Retrieves rules that match the execution stage.
        /// </summary>
        /// <remarks>
        /// Defaults to login_success.
        /// </remarks>
        public string Stage { get; set; }
    }
}