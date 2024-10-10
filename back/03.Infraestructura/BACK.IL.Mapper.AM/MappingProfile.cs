using AutoMapper;
using BACK.CORE.Entities;
using BACK.CORE.Resources;

namespace BACK.IL.Mapper.AM
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region User

            CreateMap<User, UserResource>()
                ;

            CreateMap<UserResource, User>()
                .ForMember(e => e.UserId, opt => opt.Ignore())
                ;

            CreateMap<User, User>()
                .ForMember(e => e.UserId, opt => opt.Ignore())
                ;

            #endregion

            #region Role

            CreateMap<Role, RoleResource>();

            CreateMap<RoleResource, Role>()
                .ForMember(r => r.RoleId, opt => opt.Ignore())
                ;

            CreateMap<Role, Role>()
                .ForMember(r => r.RoleId, opt => opt.Ignore())
                ;

            #endregion
        }
    }
}