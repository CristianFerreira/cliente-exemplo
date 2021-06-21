using IDP.DBX;
using IDP.Monitor.Logs;
using IDP.Monitor.Logs.Fallbacks;
using IDP.Monitor.Logs.Fallbacks.Types.Database;

namespace Epharma.Client.Test.Configurations
{
    public static class LogServiceInstance
    {
        public static ILogService Create()
        {
            var dataContext = CreateDataContext();
            var fallback = CreateDatabaseLogFallback(dataContext);
            return CreateLogService(fallback);
        }

        private static IDataContext CreateDataContext()
        {
            var sqlConnectionString = "Server=192.168.177.102;Database=IDP_Delivery_Pre;User ID=ComprProgrm;Password=ComprProgrm@1234";
            return new DataContextFactory().CreateDataContext(sqlConnectionString);
        }
        private static ILogFallback CreateDatabaseLogFallback(IDataContext dataContext)
        {
            var databaseLogFallbackFactory = new DatabaseLogFallbackFactory();
            return databaseLogFallbackFactory.CreateLogFallback(dataContext);
        }

        private static ILogService CreateLogService(ILogFallback logFallback)
        {
            var messageLogBrokerUri = "amqp://idp:6Zfbw$wEq@40.122.104.51:5672";
            var exchange = "IDP_LogExchange";
            var queue = "IDP_LogSaveQueue";
            var applicationName = "CompraProgramada";
            var logConfiguration = new LogConfiguration(messageLogBrokerUri, exchange, queue, applicationName);
            return new LogFactory().CreateLog(logConfiguration, logFallback);
        }
    }
}
