using BACK.CORE.Entities;
using BACK.CORE.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BACK.IL.Repository;

namespace BACK.IL.Repository.EF.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(Context context) : base(context) { }
        public Context? Context
        {
            get { return Context as Context; }
        }

        public Role GetRoleByType(string type)
        {
            return Context.Roles.Where(r => r.RoleType == type).FirstOrDefault();
        }
    }
}
