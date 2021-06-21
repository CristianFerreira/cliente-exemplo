using System;

namespace Epharma.Client.Library.EpharmaAuthorizer
{
    public class EpharmaAuthorizerConfiguration : IAuthorizerConfiguration
    {
        public Uri Uri { get; private set; }
        public IAuthenticationConfiguration AuthenticationConfiguration { get; private set; }

        public EpharmaAuthorizerConfiguration(Uri uri, IAuthenticationConfiguration authenticationConfiguration)
        {
            if (uri == null)
            {
                throw new ArgumentNullException(nameof(uri));
            }

            if (!uri.AbsoluteUri.EndsWith("/"))
            {
                uri = new Uri(string.Concat(uri.AbsoluteUri, "/"));
            }
            Uri = uri;
            AuthenticationConfiguration = authenticationConfiguration ?? throw new ArgumentNullException(nameof(IAuthenticationConfiguration)); ;
        }
    }
}
