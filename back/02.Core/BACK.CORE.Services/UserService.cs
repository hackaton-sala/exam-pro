using AutoMapper;
using BACK.CORE.Entities;
using BACK.CORE.Interfaces;
using BACK.CORE.Interfaces.Services;
using BACK.CORE.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public User Add(User User)
        {
            _unitOfWork.Users.Add(User);
            _unitOfWork.Complete();
            return User;
        }

        public void Delete(User User)
        {
            _unitOfWork.Users.Remove(User);
            _unitOfWork.Complete();
        }

        public User Get(Guid id)
        {
            return _unitOfWork.Users.Get(id);
        }

        public IEnumerable<User> GetList()
        {
            return _unitOfWork.Users.GetAll();
        }

        public void Update(User UserOld, User UserNew)
        {
            _mapper.Map<User, User>(UserNew, UserOld);
            _unitOfWork.Complete();
        }

        public LoginQuery GetUserFull(Guid UserId)
        {
            return _unitOfWork.Users.GetUserFull(UserId);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _unitOfWork.Users.FindByEmailAsync(email);
        }

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            return await _unitOfWork.Users.CheckPasswordAsync(user, password);
        }
    }
}
