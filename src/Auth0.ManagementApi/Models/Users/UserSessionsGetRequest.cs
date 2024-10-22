namespace Auth0.ManagementApi.Models.Users
{
    /// <summary>
    /// Represents the information required to Get User's sessions
    /// </summary>
    public class UserSessionsGetRequest
    {
        /// <summary>
        /// Id of the user to get sessions for
        /// </summary>
        public string UserId { get; set; }
    }
}