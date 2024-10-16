using AutoMapper;
using BACK.CORE.Interfaces;
using BACK.CORE.Interfaces.Services;
using Microsoft.Extensions.Configuration;

namespace BACK.CORE.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            UserService = new UserService(_unitOfWork, _mapper);
            RoleService = new RoleService(_unitOfWork, _mapper);
            GramaticalExamService = new GramaticalExamService(_unitOfWork, _mapper);
        }
        public IUserService UserService { get; private set; }
        public IRoleService RoleService { get; private set; }

        public IGramaticalExamService GramaticalExamService {  get; private set; }
    }
}