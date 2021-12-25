using System.Threading.Tasks;
using Disney.Core.Entities;

namespace Disney.Core.Interfaces
{
    public interface ISecurityRepository : IRepository<Security>
        {
            Task<Security> GetLoginByCredentials(UserLogin login);
        }
}