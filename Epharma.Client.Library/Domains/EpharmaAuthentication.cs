namespace Epharma.Client.Library.Domains
{
    public class EpharmaAuthentication : IAuthentication
    {
        public IAuthorizerToken Token { get; private set; }

        public static EpharmaAuthentication FromToken(IAuthorizerToken token)
        {
            return new EpharmaAuthentication(token);
        }

        private EpharmaAuthentication(IAuthorizerToken authorizerToken)
        {
            Token = authorizerToken;
        }
    }
}
