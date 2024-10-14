using BACK.CORE.Entities;
using BACK.CORE.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Interfaces.Services
{
    public interface IUserService : IService<User>
    {
        Task<User> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(User user, string password);
        LoginQuery GetUserFull(int UserId);
    }
}
