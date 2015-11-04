using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth0
{
    public class OAuthException : Exception
    {
        public OAuthException(string description, string code)
            : base(description)
        {
            Code = code;
        }

        public OAuthException(string description, string code, Exception innerException)
            : base(description, innerException)
        {
            Code = code;
        }

        public string Code { get; private set; }
        public string Description { get { return this.Message; } }
    }
}
