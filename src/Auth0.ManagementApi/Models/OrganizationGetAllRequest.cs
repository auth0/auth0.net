namespace Auth0.ManagementApi.Models
{
    public class OrganizationGetAllInvitationsRequest : OrganizationGetInvitationRequest
    {
        /// <summary>
        /// Field to sort by.
        /// </summary>
        /// <remarks>
        /// Use field:order where order is 1 for ascending and -1 for descending Defaults to created_at:-1.
        /// </remarks>
        public string Sort { get; set; } = null;

    }
}