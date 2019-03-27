namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Specifies criteria to use when querying all roles.
    /// </summary>
    public class GetRolesRequest
    {
        /// <summary>
        /// A string to filter by, empty to retrieve all roles.
        /// </summary>
        public string NameFilter { get; set; }
    }
}
