namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Specifies criteria to use when querying logs for a user.
    /// </summary>
    public class GetUserLogsRequest
    {
        /// <summary>
        /// The field to use for sorting.
        /// </summary>
        /// <remarks>
        /// Use field:order where order is 1 for ascending and -1 for descending. For example date:-1
        /// </remarks>
        public string Sort { get; set; } = null;

        /// <summary>
        /// The user id of the user whose logs should be retrieved.
        /// </summary>
        public string UserId { get; set; } = null;
    }
}