﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACK.CORE.Entities
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set;}
        public string RoleType { get; set; }

        public IList<User> Users { get; set; }
    }
}
