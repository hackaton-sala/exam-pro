using BACK.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Interfaces.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetRoleByType(string type);
    }
}
