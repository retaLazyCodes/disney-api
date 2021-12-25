using System.Threading.Tasks;
using Disney.Core.Entities;

namespace Disney.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}