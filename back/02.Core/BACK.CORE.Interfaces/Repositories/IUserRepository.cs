using BACK.CORE.Entities;
using BACK.CORE.Queries;

namespace BACK.CORE.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        LoginQuery GetUserFull(int UserId);
        Task<User> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(User user, string password);

    }
}
