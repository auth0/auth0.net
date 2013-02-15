using System;

namespace Auth0.Net
{
    class AccessToken
    {
        public AccessToken(DateTime retrievedIn, string token)
        {
            RetrievedIn = retrievedIn;
            Token = token;
        }

        public DateTime RetrievedIn { get; private set; }
        public string Token { get; private set; }
    }
}