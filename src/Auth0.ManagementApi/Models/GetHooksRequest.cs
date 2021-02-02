namespace Auth0.ManagementApi.Models
{
    public class GetHooksRequest
    {
        /// <summary>
        /// If provided retrieves hooks that match the value, otherwise all hooks are retrieved.
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

    }
}