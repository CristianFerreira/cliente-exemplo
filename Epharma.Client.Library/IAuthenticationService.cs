using Epharma.Client.Library.Domains;
using System.Threading.Tasks;

namespace Epharma.Client.Library
{
    public interface IAuthenticationService
    {
        Task<IAuthentication> GetAuthentication();
    }
}
