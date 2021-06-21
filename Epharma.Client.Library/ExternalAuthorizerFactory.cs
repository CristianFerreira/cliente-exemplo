using Epharma.Client.Library.Domains;
using Epharma.Client.Library.EpharmaAuthorizer;
using IDP.Cache.Library;
using IDP.Monitor.Logs;

namespace Epharma.Client.Library
{
    public class ExternalAuthorizerFactory : IExternalAuthorizerFactory
    {
        private readonly ILogService logService;
        private readonly ICacheRepository cacheRepository;
        private readonly IAuthorizerCacheKeyPrefix cacheKeyPrefix;

        public ExternalAuthorizerFactory(ILogService logService, ICacheRepository cacheRepository, IAuthorizerCacheKeyPrefix cacheKeyPrefix)
        {
            this.logService = logService;
            this.cacheRepository = cacheRepository;
            this.cacheKeyPrefix = cacheKeyPrefix;
        }

        public IExternalAuthorizerClient Create(IAuthorizerConfiguration authorizerConfiguration)
        {
            var epharmaService = new EpharmaAuthenticationService(authorizerConfiguration.Uri, authorizerConfiguration.AuthenticationConfiguration);
            var cacheServiceDecorator = new CacheAuthenticationServiceDecorator(epharmaService, cacheRepository, cacheKeyPrefix);
            var epharmaAuthorizerClient = new EpharmaAuthorizerClient(authorizerConfiguration, cacheServiceDecorator);

            return new LogPerformanceExternalAuthorizerClientDecorator(epharmaAuthorizerClient, logService);
        }
    }
}
