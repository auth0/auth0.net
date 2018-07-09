namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Specifies criteria to use when querying all clients.
    /// </summary>
    public class GetClientsRequest
    {
        /// <summary>
        /// List of application types used to filter the returned clients.
        /// </summary>
        public ClientApplicationType[] AppType { get; set; } = null;

        /// <summary>
        /// A comma separated list of fields to include or exclude (depending on <see cref="IncludeFields"/>) from the result, empty to retrieve all fields.
        /// </summary>
        public string Fields { get; set; } = null;

        /// <summary>
        /// Specifies whether the fields specified in <see cref="Fields"/> should be included or excluded in the result.
        /// </summary>
        public bool? IncludeFields { get; set; } = null;

        /// <summary>
        /// Filter on the global client parameter.
        /// </summary>
        public bool? IsGlobal { get; set; } = null;

        /// <summary>
        /// Filter on whether or not a client is a first party client.
        /// </summary>
        public bool? IsFirstParty { get; set; } = null;
    }
}