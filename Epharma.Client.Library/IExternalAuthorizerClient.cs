using System.Threading.Tasks;

namespace Epharma.Client.Library
{
    public interface IExternalAuthorizerClient
    {
        Task<bool> CallExample();
    }
}
