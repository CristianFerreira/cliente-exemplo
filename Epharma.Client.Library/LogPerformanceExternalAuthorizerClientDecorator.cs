using IDP.Monitor.Logs;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Epharma.Client.Library
{
    public class LogPerformanceExternalAuthorizerClientDecorator : IExternalAuthorizerClient
    {
        private readonly IExternalAuthorizerClient decored;
        private readonly ILogService logService;

        public LogPerformanceExternalAuthorizerClientDecorator(IExternalAuthorizerClient decored, ILogService logService)
        {
            this.decored = decored;
            this.logService = logService;
        }

        public Task<bool> CallExample()
        {
            var timer = new Stopwatch();
            timer.Start();
            var result = decored.CallExample();
            timer.Stop();
            SendRuntimeLog(timer, nameof(decored.CallExample));

            return result;
        }

        private void SendRuntimeLog(Stopwatch timer, string actionName)
        {
            logService.Log($"ExternalAuthorizerClientInfo: [the execution time was: {timer.Elapsed} on method call: {actionName}");
        }
    }
}
