namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Specifies criteria to use when querying all client grants.
    /// </summary>
    public class GetClientGrantsRequest
    {
        /// <summary>
        ///  URL Encoded audience of a client grant to filter.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        ///  The Id of a client to filter by. 
        /// </summary>
        public string ClientId { get; set; }   
        
        /// <summary>
        /// If enabled, any organization can be used with this grant. If disabled (default), the grant must be explicitly assigned to the desired organizations. 
        /// </summary>
        public bool? AllowAnyOrganization { get; set; }  
    }
}