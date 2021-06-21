using Epharma.Client.Library;
using Epharma.Client.Library.Domains;
using Epharma.Client.Library.EpharmaAuthorizer;
using Epharma.Client.Test.Configurations;
using IDP.Cache.Library;
using IDP.Monitor.Logs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Epharma.Client.Test
{
    [TestClass]
    public class ExternalAuthorizerFactoryTest
    {
        public ExternalAuthorizerFactoryTest()
        {
            cacheRepository = CacheRepositoryInstance.CreateCacheRepository();
            logService = LogServiceInstance.Create();
        }

        public readonly ICacheRepository cacheRepository;
        public readonly ILogService logService;

        [TestMethod]
        public void ExampleShouldReturnNotNull()
        {
            var cacheKeyPrefix = new CacheKeyPrefix("Epharma");
            var authenticationConfiguration = new EpharmaAuthenticationConfiguration("epharma", "123", "123");
            var authorizerConfiguration = new EpharmaAuthorizerConfiguration(new Uri("http://servicesqa.epharma.com.br/Beneficiary/api/v1/"), authenticationConfiguration);
            var authorizerClientFactory = new ExternalAuthorizerFactory(logService, cacheRepository, cacheKeyPrefix);

            var authorizerClient = authorizerClientFactory.Create(authorizerConfiguration);
            var result = authorizerClient.CallExample().GetAwaiter().GetResult();
            Assert.IsNotNull(result);
        }
    }
}
