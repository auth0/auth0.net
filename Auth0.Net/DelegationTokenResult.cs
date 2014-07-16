using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth0
{
    /// <summary>
    /// Contains the result from the Delegation endpoint.
    /// </summary>
    public class DelegationTokenResult
    {

        /// <summary>
        /// Creates a new instance of <see cref="DelegationTokenResult"/> the class.
        /// </summary>
        internal DelegationTokenResult()
        {
        }

        /// <summary>
        /// Gets the delegation id token.
        /// </summary>
        public string IdToken { get; internal set; }

        /// <summary>
        /// Gets the last instant in time at which this security token is valid.
        /// </summary>
        public DateTime ValidTo { get; internal set; }

        /// <summary>
        /// Gets the first instant in time at which this security token is valid.
        /// </summary>
        public DateTime ValidFrom { get; internal set; }

        /// <summary>
        /// Gets the type of the returned token.
        /// </summary>
        public string TokenType { get; internal set; }
    }
}
