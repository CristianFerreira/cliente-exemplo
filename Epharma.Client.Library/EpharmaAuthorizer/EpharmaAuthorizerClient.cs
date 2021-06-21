using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Epharma.Client.Library.EpharmaAuthorizer
{
    internal class EpharmaAuthorizerClient : IExternalAuthorizerClient
    {
        private static readonly HttpClient DefaultHttpClient;
        public IAuthenticationService AuthenticationService { get; }

        private static void ConfigureTls()
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        static EpharmaAuthorizerClient()
        {
            DefaultHttpClient = new HttpClient();
        }

        public EpharmaAuthorizerClient(IAuthorizerConfiguration authorizerConfiguration, IAuthenticationService authenticationService)
        {
            if (authorizerConfiguration == null)
            {
                throw new ArgumentNullException(nameof(IAuthorizerConfiguration));
            }

            if (authenticationService == null)
            {
                throw new ArgumentNullException(nameof(IAuthenticationService));
            }

            AuthenticationService = authenticationService;

            if (DefaultHttpClient.BaseAddress == null)
            {
                DefaultHttpClient.BaseAddress = authorizerConfiguration.Uri;
            }
        }

        public async Task<bool> CallExample()
        {
            return await Task.FromResult(true);
        }
    }
}
