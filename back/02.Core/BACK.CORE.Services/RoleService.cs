using AutoMapper;
using BACK.CORE.Entities;
using BACK.CORE.Interfaces;
using BACK.CORE.Interfaces.Services;

namespace BACK.CORE.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Role Add(Role Rol)
        {
            _unitOfWork.Roles.Add(Rol);
            _unitOfWork.Complete();
            return Rol;
        }

        public void Delete(Role Rol)
        {
            _unitOfWork.Roles.Remove(Rol);
            _unitOfWork.Complete();
        }

        public Role Get(int id)
        {
            return _unitOfWork.Roles.Get(id);
        }

        public IEnumerable<Role> GetList()
        {
            return _unitOfWork.Roles.GetAll();
        }

        public void Update(Role rolOld, Role rolNew)
        {
            _mapper.Map<Role, Role>(rolNew, rolOld);
            _unitOfWork.Complete();
        }

        public Role GetRoleByType(string type)
        {
            return _unitOfWork.Roles.GetRoleByType(type);
        }
    }
}
