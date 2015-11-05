namespace Auth0.Core.Models
{
    public class BlacklistTokenBase
    {
        /// <summary>
        /// Gets or sets the JWT's aud claim. The Client identifier of the client for which it was issued.
        /// </summary>
        public string Aud { get; set; }

        /// <summary>
        /// Gets or sets the jti of the JWT to be blacklisted.
        /// </summary>
        public string Jti { get; set; }        
    }
}