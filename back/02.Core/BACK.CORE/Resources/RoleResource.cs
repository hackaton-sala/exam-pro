using BACK.CORE.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Resources
{
    public class RoleResource
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleType { get; set; }
        public IList<UserResource> Users { get; set; }

    }
}
