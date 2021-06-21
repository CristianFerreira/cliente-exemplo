using IDP.Cache.Library;

namespace Epharma.Client.Test.Configurations
{
    public static class CacheRepositoryInstance
    {
        public static ICacheRepository CreateCacheRepository()
        {
            var cacheFactory = new CacheRepositoryFactory();
            return cacheFactory.CreateMemoryRepository();
        }
    }
}
