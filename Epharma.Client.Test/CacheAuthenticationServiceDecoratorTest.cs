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
    public class CacheAuthenticationServiceDecoratorTest
    {
        public CacheAuthenticationServiceDecoratorTest()
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
            var epharmaService = new EpharmaAuthenticationService(authorizerConfiguration.Uri, authorizerConfiguration.AuthenticationConfiguration);
            var cacheServiceDecorator = new CacheAuthenticationServiceDecorator(epharmaService, cacheRepository, cacheKeyPrefix);
            var result = cacheServiceDecorator.GetAuthentication().GetAwaiter().GetResult();
            Assert.IsNotNull(result);
        }
    }
}
