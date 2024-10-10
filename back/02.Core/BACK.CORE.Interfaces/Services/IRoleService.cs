using BACK.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Interfaces.Services
{
    public interface IRoleService : IService<Role>
    {
        Role GetRoleByType(string type);
    }
}
