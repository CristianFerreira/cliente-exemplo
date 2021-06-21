using System;

namespace Epharma.Client.Library.Domains
{
    public sealed class TokenKey
    {
        public string Value { get; private set; }
        public static TokenKey FromString(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Token key can'b null.");
            }
            return new TokenKey(key);
        }

        private TokenKey(string value)
        {
            Value = value;
        }
    }
}
