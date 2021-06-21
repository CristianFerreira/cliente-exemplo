using System;

namespace Epharma.Client.Library.Domains
{
    public class CacheKeyPrefix : IAuthorizerCacheKeyPrefix
    {
        public string Value { get; private set; }

        public CacheKeyPrefix(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
