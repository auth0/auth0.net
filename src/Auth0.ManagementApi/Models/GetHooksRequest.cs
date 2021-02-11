namespace Auth0.ManagementApi.Models
{
    public class GetHooksRequest
    {
        /// <summary>
        /// If provided retrieves hooks that match the value, otherwise all hooks are retrieved.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// A Comma-separated list of fields to include in the result. Leave empty to retrieve all fields.
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// Gets or sets the triggerId of the hook. 
        /// </summary>
        public string TriggerId { get; set; }

    }
}