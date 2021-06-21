using Epharma.Client.Library.Domains;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Epharma.Client.Library.EpharmaAuthorizer
{
    public class EpharmaAuthenticationService : IAuthenticationService
    {
        private static readonly HttpClient DefaultHttpClient;
        private readonly IAuthenticationConfiguration AuthenticationConfiguration;
        private static void ConfigureTls()
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        static EpharmaAuthenticationService()
        {
            DefaultHttpClient = new HttpClient();
        }

        public EpharmaAuthenticationService(Uri uri, IAuthenticationConfiguration authenticationConfiguration)
        {
            DefaultHttpClient.BaseAddress = uri;
            AuthenticationConfiguration = authenticationConfiguration ?? throw new ArgumentNullException(nameof(IAuthenticationConfiguration));
        }

        public async Task<IAuthentication> GetAuthentication()
        {
            IAuthorizerToken tokenFake = AuthorizerToken.FromKey(TokenKey.FromString(Guid.NewGuid().ToString()));
            var authentication = EpharmaAuthentication.FromToken(tokenFake);
            return await Task.FromResult(authentication);
        }
    }
}
