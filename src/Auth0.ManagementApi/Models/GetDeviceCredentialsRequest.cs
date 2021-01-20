namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Specifies criteria to use when querying all device credentials.
    /// </summary>
    public class GetDeviceCredentialsRequest
    {
        /// <summary>
        /// Comma-separated list of fields to include or exclude (based on value provided for include_fields) in the result. Leave empty to retrieve all fields.
        /// </summary>
        public string Fields { get; set; }
        /// <summary>
        /// Whether specified fields are to be included (true) or excluded (false).
        /// </summary>
        public bool IncludeFields { get; set; } = true;
        /// <summary>
        /// user_id of the devices to retrieve.
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// client_id of the devices to retrieve.
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// Type of credentials to retrieve. Must be `public_key`, `refresh_token` or `rotating_refresh_token`. The property will default to `refresh_token` when paging is requested
        /// </summary>
        public string Type { get; set; }
    }
}
