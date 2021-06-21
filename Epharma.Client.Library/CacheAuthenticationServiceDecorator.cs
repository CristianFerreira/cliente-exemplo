using Epharma.Client.Library.Domains;
using IDP.Cache.Library;
using System;
using System.Threading.Tasks;

namespace Epharma.Client.Library
{
    public class CacheAuthenticationServiceDecorator : IAuthenticationService
    {
        private static readonly TimeSpan CacheExpiration = TimeSpan.FromHours(4);
        private readonly IAuthenticationService decorated;
        private readonly ICacheRepository cacheRepository;
        private readonly IAuthorizerCacheKeyPrefix cacheKeyPrefix;

        public CacheAuthenticationServiceDecorator(IAuthenticationService decorated, ICacheRepository cacheRepository, IAuthorizerCacheKeyPrefix cacheKeyPrefix)
        {
            this.decorated = decorated;
            this.cacheRepository = cacheRepository;
            this.cacheKeyPrefix = cacheKeyPrefix;
        }

        public async Task<IAuthentication> GetAuthentication()
        {
            var cacheKey = new AuthenticationConsumerKey(cacheKeyPrefix);
            if (!cacheRepository.TryGet(cacheKey, out var rawCached))
            {
                var cached = await decorated.GetAuthentication();
                if (cached != null)
                {
                    await cacheRepository.AddAsync(cacheKey, cached, CacheExpiration);
                }

                return cached;
            }
            return (IAuthentication)rawCached;
        }


        private class AuthenticationConsumerKey : ICacheKey
        {
            private readonly string keyPrefix;

            public string Value
            {
                get { return $"{keyPrefix}{typeof(IAuthentication).Name}"; }
            }

            public AuthenticationConsumerKey(IAuthorizerCacheKeyPrefix keyPrefix)
            {
                this.keyPrefix = keyPrefix.Value;
            }
        }
    }
}
