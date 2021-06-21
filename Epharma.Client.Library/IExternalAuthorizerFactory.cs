namespace Epharma.Client.Library
{
    public interface IExternalAuthorizerFactory
    {
        IExternalAuthorizerClient Create(IAuthorizerConfiguration authorizerConfiguration);
    }
}
