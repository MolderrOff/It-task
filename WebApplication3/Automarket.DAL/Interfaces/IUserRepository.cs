using Itmytask.Domain.Entity;
using System.Threading.Tasks;

namespace Itmytask.DAL.Interfaces
{
    public interface IUserRepository : IBaseRepository<Users>
    {
        Task<Users> GetByNameAsyncU(string name);
    }

}
