using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Auth0
{
    internal enum IdentifierType
    {
        Email,
        UserName
    }

    public class UserIdentifier
    {
        private UserIdentifier(string value, IdentifierType type)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("value");
            }

            this.Value = value;
            this.Type = type;
        }

        public string Value { get; private set; }

        internal IdentifierType Type { get; private set; }

        public static UserIdentifier Email(string value)
        {
            return new UserIdentifier(value, IdentifierType.Email);
        }

        public static UserIdentifier UserName(string value)
        {
            return new UserIdentifier(value, IdentifierType.UserName);
        }
    }
}
