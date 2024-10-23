namespace Auth0.ManagementApi.Models.Sessions
{
    /// <summary>
    /// Represents the information required to Get <see cref="Sessions"/>
    /// </summary>
    public class SessionsGetRequest
    {
        /// <summary>
        /// ID of session to retrieve
        /// </summary>
        public string Id { get; set; }
    }
}