using System;

namespace Epharma.Client.Library.EpharmaAuthorizer
{
    public class EpharmaAuthenticationConfiguration : IAuthenticationConfiguration
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string ClientId { get; private set; }

        public EpharmaAuthenticationConfiguration(string userName, string password, string clientId)
        {
            UserName = userName;
            Password = password;
            ClientId = clientId;
        }
    }
}
