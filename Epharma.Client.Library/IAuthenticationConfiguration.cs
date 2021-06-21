namespace Epharma.Client.Library
{
    public interface IAuthenticationConfiguration
    {
        string UserName { get; }
        string Password { get; }
        string ClientId { get; }
    }
}
