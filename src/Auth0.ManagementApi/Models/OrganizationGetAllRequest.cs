namespace Auth0.ManagementApi.Models
{
    public class OrganizationGetAllRequest : OrganizationGetRequest
    {
        /// <summary>
        /// Field to sort by. Use field:order where order is 1 for ascending and -1 for descending Defaults to created_at:-1.
        /// </summary>
        public string Sort { get; set; } = null;

    }
}