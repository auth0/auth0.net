namespace Auth0.AuthenticationApi.Models
{
    public class MfaOobTokenRequest : IClientAuthentication
    {
        /// <summary>
        /// Your application's Client ID.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Your application's Client Secret.
        /// Required when the Token Endpoint Authentication Method field at your Application Settings is Post or Basic.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Security Key to use with Client Assertion
        /// </summary>
        public SecurityKey ClientAssertionSecurityKey { get; set; }

        /// <summary>
        /// Algorithm for the Security Key to use with Client Assertion
        /// </summary>
        public string ClientAssertionSecurityKeyAlgorithm { get; set; }
        
        /// <summary>
        /// The mfa_token you received from mfa_required error or access token with enroll scope and audience: https://{yourDomain}/mfa/
        /// </summary>
        public string MfaToken { get; set; }

        /// <summary>
        /// The oob code received from the challenge request.
        /// </summary>
        public string OobCode { get; set; }

        /// <summary>
        /// A code used to bind the side channel (used to deliver the challenge) with the main channel you are using to authenticate.
        /// This is usually an OTP-like code delivered as part of the challenge message.
        /// </summary>
        public string BindingCode { get; set; }
    }
}
