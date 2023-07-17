namespace Auth0.ManagementApi.Models.Grants
{
    public class GetGrantsRequest
    {
        /// <summary>
        /// Id of the user of the grants to retrieve.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Id of the client of the grants to retrieve.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Audience of the grants to retrieve.
        /// </summary>
        public string Audience { get; set; }
    }
}
