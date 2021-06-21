namespace Epharma.Client.Library.Domains
{
    public sealed class AuthorizerToken : IAuthorizerToken
    {
        public TokenKey Key { get; private set; }

        public static AuthorizerToken FromKey(TokenKey key)
        {
            return new AuthorizerToken(key);
        }

        private AuthorizerToken(TokenKey key)
        {
            Key = key;
        }
    }
}
