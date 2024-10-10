using BACK.CORE.Entities;
using BACK.CORE.Interfaces.Repositories;
using BACK.CORE.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BACK.IL.Repository;

namespace BACK.IL.Repository.EF.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context) { }
        public Context? Context
        {
            get { return Context as Context; }
        }
        public LoginQuery GetUserFull(Guid UserId)
        {
            var a = Context.Users
                .Where(e => e.UserId == UserId)
                .Select(e => new LoginQuery()
                {
                    UserId = e.UserId,
                    Name = e.Name,
                    LastName = e.LastName,
                    Email = e.Email,
                    PhoneNumber = e.PhoneNumber,
                    BirthDate = e.BirthDate,
                    ID = e.ID,
                    Gender = e.Gender,
                    Avatar = e.Avatar,
                    Points = e.Points,
                    CreateDate = e.CreateDate,

                    Role = new RoleLoginQuery()
                    {
                        RoleId = e.RoleId,
                        RoleName = e.Role.RoleName,
                        RoleType = e.Role.RoleType
                    }

                }).FirstOrDefault();
            return a;
        }

        public async Task<bool> CheckPasswordAsync(User User, string password)
        {
            var UserPass = await Context.Users.Where(e => e.UserId == User.UserId).Select(e => e.Password).FirstOrDefaultAsync();
            return UserPass == password;
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await Context.Users.Where(e => e.Email == email).FirstOrDefaultAsync();
        }
    }
}
