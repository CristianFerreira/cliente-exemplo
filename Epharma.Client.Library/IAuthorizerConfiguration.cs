using Epharma.Client.Library.EpharmaAuthorizer;
using System;

namespace Epharma.Client.Library
{
    public interface IAuthorizerConfiguration
    {
        Uri Uri { get; }
        IAuthenticationConfiguration AuthenticationConfiguration { get; }
    }
}
